namespace FreshVegCart.Api.Data.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(20)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Phone { get; set; }

    [Required, StringLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    public virtual ICollection<UserAddress> Addresses { get; set; } = [];
}
