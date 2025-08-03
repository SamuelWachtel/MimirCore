using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
        
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    [Required]
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
        
    [Required]
    [StringLength(100)]
    public string CreatedBy { get; set; }
        
    [Required]
    [StringLength(100)]
    public string ModifiedBy { get; set; }
        
    [Timestamp]
    public byte[] ETag { get; set; }
        
    public bool IsDeleted { get; set; } = false;
}