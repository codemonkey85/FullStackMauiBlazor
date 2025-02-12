using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Api.Data.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    [Required, MaxLength(500)]
    public string PasswordHash { get; set; } = string.Empty;

    public virtual ICollection<UserAddress> Addresses { get; set; } = [];
}
