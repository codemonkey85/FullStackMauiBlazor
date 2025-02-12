using FreshVegCart.Api.Services;
using FreshVegCart.Shared.Library.Dtos;

namespace FreshVegCart.Api.Endpoints;

public static class Auth
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder apiGroup)
    {
        var group = apiGroup
            .MapGroup("/auth")
            .WithTags("Auth");

        group.MapPost("register", Register);
        group.MapPost("login", LogIn);

        return apiGroup;
    }

    private static async Task<IResult> Register(RegisterDto dto, AuthService authService)
    {
        var result = await authService.Register(dto);
        return Results.Ok(result);
    }

    private static async Task<IResult> LogIn(LoginDto dto, AuthService authService)
    {
        var result = await authService.LogIn(dto);
        return Results.Ok(result);
    }
}
