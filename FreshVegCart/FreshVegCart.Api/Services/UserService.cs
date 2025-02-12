namespace FreshVegCart.Api.Services;

public class UserService(DataContext dataContext, IPasswordHasher<User> passwordHasher) : ServiceBase(dataContext)
{
    public async Task<ApiResult> SaveAddress(AddressDto dto, int userId)
    {
        try
        {
            if (dto.IsDefault)
            {
                var existingDefaultAddresses = await DataContext.UserAddresses
                    .Where(a => a.UserId == userId && a.IsDefault)
                    .ToListAsync();

                foreach (var address in existingDefaultAddresses)
                {
                    address.IsDefault = false;
                }
            }

            if (dto.Id == 0)
            {
                await DataContext.UserAddresses.AddAsync(new()
                {
                    UserId = userId, Address = dto.Address, Name = dto.Name, IsDefault = dto.IsDefault
                });
            }
            else
            {
                var existingAddress = await DataContext.UserAddresses
                    .FirstOrDefaultAsync(a => a.Id == dto.Id && a.UserId == userId);

                if (existingAddress is null)
                {
                    return ApiResult.Fail("Failed to save address.");
                }

                existingAddress.Address = dto.Address;
                existingAddress.Name = dto.Name;
                existingAddress.IsDefault = dto.IsDefault;
            }
        }
        catch (Exception ex)
        {
            // Log the Exception
            // Send some user friendly error message to the client
            return ApiResult.Fail(ex.Message);
        }

        return await DataContext.SaveChangesAsync() > 0
            ? ApiResult.Success("Address saved successfully.")
            : ApiResult.Fail("Failed to save address.");
    }

    public async Task<AddressDto[]> GetAddresses(int userId) =>
        await DataContext.UserAddresses
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .Select(a => new AddressDto { Id = a.Id, Address = a.Address, Name = a.Name, IsDefault = a.IsDefault })
            .ToArrayAsync();

    public async Task<ApiResult> ChangePassword(ChangePasswordDto dto, int userId)
    {
        try
        {
            var user = await DataContext.Users.FindAsync(userId);
            if (user is null)
            {
                return ApiResult.Fail("User not found.");
            }

            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.CurrentPassword);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return ApiResult.Fail("Invalid current password.");
            }

            user.PasswordHash = passwordHasher.HashPassword(user, dto.NewPassword);
            await DataContext.SaveChangesAsync();

            return ApiResult.Success("Password changed successfully.");
        }
        catch (Exception ex)
        {
            // Log the Exception
            // Send some user friendly error message to the client
            return ApiResult.Fail(ex.Message);
        }
    }
}
