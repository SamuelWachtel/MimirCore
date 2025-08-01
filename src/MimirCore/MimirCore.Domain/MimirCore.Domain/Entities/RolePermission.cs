namespace MimirCore.Domain.Entities;

public class RolePermission : BaseEntity
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
        
    // Navigation properties
    public virtual Role Role { get; set; }
    public virtual Permission Permission { get; set; }
}