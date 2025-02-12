using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FreshVegCart.Shared.Library.Dtos;

public class ChangePasswordDto
{
    [Required]
    public string CurrentPassword { get; set; } = string.Empty;

    [Required]
    public string NewPassword { get; set; } = string.Empty;

    [JsonIgnore, Required, Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; set; } = string.Empty;
}
