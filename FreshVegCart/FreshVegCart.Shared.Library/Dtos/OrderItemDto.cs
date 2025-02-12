using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Library.Dtos;

public class OrderItemDto
{
    public long Id { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string ProductImageUrl { get; set; } = string.Empty;

    public decimal ProductPrice { get; set; }

    public string Unit { get; set; } = string.Empty;

    public int Quantity { get; set; }
}
