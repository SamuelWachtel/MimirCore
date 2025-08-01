using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Role : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
        
    [StringLength(200)]
    public string Description { get; set; }
        
    // Navigation properties
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}