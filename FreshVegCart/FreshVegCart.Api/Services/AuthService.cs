using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Shared.Library.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Services;

public class AuthService(DataContext dataContext, IPasswordHasher<User> passwordHasher)
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

        // Generate JWT token here
        var jwt = "";

        var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, jwt);

        return ApiResult<LoggedInUser>.Success(
            loggedInUser,
            "Login successful."
        );
    }
}
