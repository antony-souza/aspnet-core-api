using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendAspNet.modules.user.entity;
using BackendAspNet.utils;

namespace BackendAspNet.modules.order.entity;

[Table(("orders"))]
public class OrderEntity : BaseEntity
{
    [Key]
    [Column("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    
    [Column("userId")]
    public string UserId { get; set; } = string.Empty;
    
    [ForeignKey("UserId")]
    public UserEntity? User { get; set; }
    
    [Column("total")]
    public decimal Total { get; set; }
    
    [Column("paymentStatus")] 
    public PaymentStatusEnum Status { get; set; } = PaymentStatusEnum.Pending;
    
    public ICollection<OrderItemEntity>? Items { get; set; } = new List<OrderItemEntity>();
}