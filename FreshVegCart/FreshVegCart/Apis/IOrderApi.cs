using FreshVegCart.Shared.Library.Dtos;
using Refit;

namespace FreshVegCart.Apis;

[Headers("Authorization: Bearer ")]
public interface IOrderApi
{
    [Post("/api/order/place-order")]
    Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto);

    [Get("/api/order/get-orders/{userId}/{startIndex}/{pageSize}")]
    Task<OrderDto[]> GetOrdersAsync(int userId, int startIndex, int pageSize);

    [Get("/api/order/get-order-items/{userId}/{orderId}")]
    Task<OrderItemDto[]> GetOrderItemsAsync(int userId, int orderId);
}
