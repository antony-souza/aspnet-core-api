using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAspNet.modules.user.entity;

[Table("users")]
public class UserEntity
{
    [Key]
    [Column("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("password")]
    public string Password { get; set; } = string.Empty;
    
    [Column("enabled")]
    public bool? Enabled { get; set; } = true;
};