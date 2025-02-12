using FreshVegCart.Shared.Library.Dtos;
using Refit;

namespace FreshVegCart.Apis;

public interface IAuthApi
{
    [Post("/api/auth/register")]
    Task<ApiResult> Register(RegisterDto dto);

    [Post("/api/auth/login")]
    Task<ApiResult> LogIn(LoginDto dto);
}
