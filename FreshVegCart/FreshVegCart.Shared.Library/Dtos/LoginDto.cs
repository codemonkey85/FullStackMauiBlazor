using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Library.Dtos;

public class LoginDto
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
