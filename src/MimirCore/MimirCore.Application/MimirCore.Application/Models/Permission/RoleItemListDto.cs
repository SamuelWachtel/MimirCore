namespace MimirCore.Application.Models.Permission;

// Role ItemListDto - brief version for lists
public class RoleItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PermissionCount { get; set; }
}