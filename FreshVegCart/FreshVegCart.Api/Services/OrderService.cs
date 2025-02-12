using FreshVegCart.Api.Data;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Shared.Library.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Services;

public class OrderService(DataContext dataContext) : ServiceBase(dataContext)
{
    public async Task<ApiResult> PlaceOrder(PlaceOrderDto dto, int userId)
    {
        var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToArray();

        var products = await DataContext.Products
            .AsNoTracking()
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(product => product.Id);

        if (products.Count != dto.Items.Length)
        {
            return ApiResult.Fail("Some products are not available.");
        }

        var orderItems = dto.Items.Select(item => new OrderItem
        {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            ProductName = products[item.ProductId].Name,
            ProductImageUrl = products[item.ProductId].ImageUrl,
            ProductPrice = products[item.ProductId].Price,
            Unit = products[item.ProductId].Unit,
        }).ToArray();

        var now = DateTime.UtcNow;

        var order = new Order
        {
            UserId = userId,
            UserAddressId = dto.UserAddressId,
            Address = dto.Address,
            AddressName = dto.AddressName,
            Date = now,
            Items = orderItems,
            ItemCount = dto.Items.Length,
            TotalAmount = orderItems.Sum(orderItem => orderItem.ProductPrice * orderItem.Quantity)
        };

        try
        {
            DataContext.Orders.Add(order);
            await DataContext.SaveChangesAsync();
            return ApiResult.Success("Order placed successfully.");
        }
        catch (Exception ex)
        {
            // Log the Exception
            // Send some user friendly error message to the client
            return ApiResult.Fail(ex.Message);
        }
    }

    public async Task<OrderDto[]> GetUserOrders(int userId, int startIndex, int pageSize)
    {
        var ordersQuery = DataContext.Orders
            .Where(order => order.UserId == userId)
            .OrderByDescending(order => order.Date)
            .Skip(startIndex)
            .Take(pageSize);

        return await ordersQuery
            .Select(order => new OrderDto
            {
                Id = order.Id,
                Date = order.Date,
                TotalAmount = order.TotalAmount,
                Remarks = order.Remarks,
                Status = order.Status,
                Address = order.Address,
                AddressName = order.AddressName,
                ItemCount = order.ItemCount
            }).ToArrayAsync();
    }

    public async Task GetUserOrderItems(int orderId, int userId)
    {
    }
}
