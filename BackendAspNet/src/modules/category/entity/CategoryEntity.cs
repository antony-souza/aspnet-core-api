using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendAspNet.utils;

namespace BackendAspNet.modules.category.entity;

[Table("categories")]
public class CategoryEntity : BaseEntity
{
    [Key]
    [Column("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [Column("name")]
    public string Name { get; set; } = string.Empty;
}