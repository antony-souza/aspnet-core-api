using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendAspNet.modules.product.entity;
using BackendAspNet.utils;

namespace BackendAspNet.modules.order.entity;

[Table("order_items")]
public class OrderItemEntity : BaseEntity
{
    [Key]
    [Column("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [Column("orderId")]
    public string OrderId { get; set; } = string.Empty;

    [ForeignKey("OrderId")]
    public OrderEntity? Order { get; set; }

    [Column("productId")]
    public string ProductId { get; set; } = string.Empty;

    [ForeignKey("ProductId")]
    public ProductEntity? Product { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("unitPrice")]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal Subtotal => Quantity * UnitPrice;
}