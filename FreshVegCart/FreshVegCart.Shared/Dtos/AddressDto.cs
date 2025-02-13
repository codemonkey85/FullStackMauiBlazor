using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class AddressDto
{
    public int Id { get; set; }

    [Required, StringLength(250)]
    public string Address { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string Name { get; set; } = string.Empty;

    public bool IsDefault { get; set; }
}
