using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Permission : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
        
    [StringLength(200)]
    public string Description { get; set; }
        
    [StringLength(50)]
    public string Module { get; set; }
        
    // Navigation properties
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}