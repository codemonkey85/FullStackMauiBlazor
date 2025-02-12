using System.Diagnostics.CodeAnalysis;
using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    [SuppressMessage("Style", "IDE0022:Use expression body for method", Justification = "<Pending>")]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ReSharper disable once ArrangeMethodOrOperatorBody
        modelBuilder.Entity<Order>()
            .Property(o => o.ItemCount)
            .HasComputedColumnSql($"""
            (SELECT COUNT(*)
            FROM {nameof(OrderItems)}
            WHERE {nameof(OrderItems)}.{nameof(OrderItem.OrderId)} = {nameof(Orders)}.{nameof(Order.Id)})
            """, stored: true);
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<UserAddress> UserAddresses { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;
}
