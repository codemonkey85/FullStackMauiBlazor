using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<UserAddress> UserAddresses { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;
}
