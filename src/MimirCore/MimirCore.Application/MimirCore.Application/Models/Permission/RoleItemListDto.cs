namespace MimirCore.Application.Models.Permission;

public class RoleItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PermissionCount { get; set; }
}