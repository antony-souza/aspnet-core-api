using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendAspNet.utils;

namespace BackendAspNet.modules.product.entity;

[Table("products")]
public class ProductEntity : BaseEntity
{
    [Key]
    [Column("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [Column("price")]
    public decimal Price { get; set; }
    
    [Column("categoryId")]
    public string CategoryId { get; set; } = string.Empty;
}