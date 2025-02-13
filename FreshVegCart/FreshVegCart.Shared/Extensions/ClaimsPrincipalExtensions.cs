using System.Security.Claims;

namespace FreshVegCart.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var userIdString = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.TryParse(userIdString, out var userId)
            ? userId
            : null;
    }
}
