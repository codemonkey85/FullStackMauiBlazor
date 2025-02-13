namespace FreshVegCart.Shared.Dtos;

public class OrderDto
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Remarks { get; set; }

    public OrderStatus Status { get; set; }

    public string Address { get; set; } = string.Empty;

    public string AddressName { get; set; } = string.Empty;

    public int ItemCount { get; set; }
}
