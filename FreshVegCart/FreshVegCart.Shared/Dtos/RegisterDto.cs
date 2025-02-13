using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class RegisterDto
{
    [Required, StringLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Phone { get; set; }

    [Required, StringLength(128, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
