using System.Security.Claims;
using FreshVegCart.Api.Services;
using FreshVegCart.Shared.Library.Dtos;
using FreshVegCart.Shared.Library.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace FreshVegCart.Api.Endpoints;

public static class User
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder apiGroup)
    {
        var group = apiGroup
            .MapGroup("/users")
            .RequireAuthorization()
            .WithTags("Users");

        group.MapPost("/addresses", SaveAddress);
        group.MapGet("/addresses/{userId:int}", GetAddresses);
        group.MapPost("change-password", ChangePassword);

        return apiGroup;
    }

    [Authorize]
    private static async Task<IResult> SaveAddress(AddressDto dto, UserService userService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() is not { } userId)
        {
            return Results.Unauthorized();
        }

        var result = await userService.SaveAddress(dto, userId);
        return Results.Ok(result);
    }

    [Authorize]
    private static async Task<IResult> GetAddresses(int userId, UserService userService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() != userId)
        {
            return Results.Unauthorized();
        }

        var addresses = await userService.GetAddresses(userId);
        return Results.Ok(addresses);
    }

    [Authorize]
    private static async Task<IResult> ChangePassword(ChangePasswordDto dto, UserService userService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() is not { } userId)
        {
            return Results.Unauthorized();
        }

        var result = await userService.ChangePassword(dto, userId);
        return Results.Ok(result);
    }
}
