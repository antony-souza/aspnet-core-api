using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackendAspNet.utils;

public class BaseEntity
{
    [Column("enabled")]
    public bool? Enabled { get; set; } = true;

    [Column("createdAt")] 
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updatedAt")] 
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}