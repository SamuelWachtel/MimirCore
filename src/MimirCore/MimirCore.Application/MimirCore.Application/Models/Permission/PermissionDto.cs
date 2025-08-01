using MimirCore.Application.Models.User;

namespace MimirCore.Application.Models.Permission;

public class PermissionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public ICollection<PermissionItemListDto> Permissions { get; set; } = new List<PermissionItemListDto>();
}

public class UserRoleDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime AssignedAt { get; set; }
    
    // Navigation properties
    public UserItemListDto User { get; set; }
    public RoleItemListDto Role { get; set; }
}