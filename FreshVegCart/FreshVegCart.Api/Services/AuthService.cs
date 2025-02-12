namespace FreshVegCart.Api.Services;

public class AuthService(DataContext dataContext, IPasswordHasher<User> passwordHasher, IOptions<JwtConfig> jwtConfig)
    : ServiceBase(dataContext)
{
    public async Task<ApiResult> Register(RegisterDto dto)
    {
        if (await DataContext.Users.AnyAsync(u => u.Email == dto.Email))
        {
            return ApiResult.Fail("Email already exists.");
        }

        var user = new User { Name = dto.Name, Email = dto.Email, Phone = dto.Phone };
        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);

        try
        {
            await DataContext.Users.AddAsync(user);
            return await DataContext.SaveChangesAsync() > 0
                ? ApiResult.Success("User registered successfully.")
                : ApiResult.Fail("User registration failed.");
        }
        catch (Exception ex)
        {
            // Log the Exception
            // Send some user friendly error message to the client
            return ApiResult.Fail(ex.Message);
        }
    }

    public async Task<ApiResult<LoggedInUser>> LogIn(LoginDto dto)
    {
        var user = await DataContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user is null)
        {
            return ApiResult<LoggedInUser>.Fail("Invalid email or password.");
        }

        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return ApiResult<LoggedInUser>.Fail("Invalid email or password.");
        }

        var jwt = GenerateToken(user);

        var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, jwt);

        return ApiResult<LoggedInUser>.Success(
            loggedInUser,
            "Login successful."
        );
    }

    private string GenerateToken(User user)
    {
        Claim[] claims =
        [
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
        ];

        var secretKey = jwtConfig.Value.SecretKey;

        var securityKey = Encoding.UTF8.GetBytes(secretKey);
        var symmetricKey = new SymmetricSecurityKey(securityKey);
        var signingCreds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var issuer = jwtConfig.Value.Issuer;
        var expirationInMinutes = jwtConfig.Value.ExpirationInMinutes;

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationInMinutes),
            signingCredentials: signingCreds);

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
