namespace FreshVegCart.Api.Data.Entities;

public class OrderItem
{
    [Key]
    public long Id { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public int ProductId { get; set; }

    [StringLength(50)]
    public string ProductName { get; set; } = string.Empty;

    [StringLength(200)]
    public string ProductImageUrl { get; set; } = string.Empty;

    [Column(TypeName = DatabaseConstants.DecimalType)]
    public decimal ProductPrice { get; set; }

    [StringLength(10)]
    public string Unit { get; set; } = string.Empty;

    public int Quantity { get; set; }
}
