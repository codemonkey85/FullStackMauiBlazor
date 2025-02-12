﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreshVegCart.Shared.Library;

namespace FreshVegCart.Api.Data.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    public int UsertId { get; set; }

    public virtual User User { get; set; } = null!;

    public DateTime Date { get; set; }

    [Column(TypeName = DatabaseConstants.DecimalType)]
    public decimal TotalAmount { get; set; }

    [StringLength(200)]
    public string? Remarks { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Placed;

    public int UserAddressId { get; set; }

    [Required, StringLength(250)]
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<OrderItem> Items { get; set; } = [];
}
