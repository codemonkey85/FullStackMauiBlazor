using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Api.Data.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    [Required, MaxLength(10)]
    public string Unit { get; set; } = string.Empty;
}
