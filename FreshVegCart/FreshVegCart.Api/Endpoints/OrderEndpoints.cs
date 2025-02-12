namespace FreshVegCart.Api.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder apiGroup)
    {
        var group = apiGroup
            .MapGroup("/orders")
            .RequireAuthorization()
            .WithTags("Orders");

        group.MapPost("/place-order", PlaceOrder);
        group.MapGet("/get-orders/{userId:int}/{startIndex:int}/{pageSize:int}", GetOrders);
        group.MapGet("/get-order-items/{userId:int}/{orderId:int}", GetOrderItems);

        return apiGroup;
    }

    [Authorize]
    private static async Task<IResult> PlaceOrder(PlaceOrderDto dto, OrderService orderService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() is not { } userId)
        {
            return Results.Unauthorized();
        }

        var result = await orderService.PlaceOrder(dto, userId);
        return Results.Ok(result);
    }

    [Authorize]
    private static async Task<IResult> GetOrders(int userId, int startIndex, int pageSize, OrderService orderService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() != userId)
        {
            return Results.Unauthorized();
        }

        var orders = await orderService.GetUserOrders(userId, startIndex, pageSize);
        return Results.Ok(orders);
    }

    [Authorize]
    private static async Task<IResult> GetOrderItems(int userId, int orderId, OrderService orderService, ClaimsPrincipal principal)
    {
        if (principal.GetUserId() != userId)
        {
            return Results.Unauthorized();
        }

        var orderItems = await orderService.GetUserOrderItems(userId, orderId);
        return Results.Ok(orderItems);
    }
}
