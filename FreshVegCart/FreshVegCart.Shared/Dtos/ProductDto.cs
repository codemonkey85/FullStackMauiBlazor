using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class ProductDto
{
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    [StringLength(10)]
    public string Unit { get; set; } = string.Empty;
}
