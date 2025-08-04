using MimirCore.Application.Models.User;

namespace MimirCore.Application.Models.Permission;

public class PermissionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public ICollection<PermissionItemListDto> Permissions { get; set; } = new List<PermissionItemListDto>();
}

public class UserRoleDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public DateTime AssignedAt { get; set; }
    
    public UserItemListDto User { get; set; }
    public RoleItemListDto Role { get; set; }
}