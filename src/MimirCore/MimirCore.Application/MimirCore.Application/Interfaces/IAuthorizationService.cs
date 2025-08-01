namespace MimirCore.Application.Interfaces;

public interface IAuthorizationService
{
    Task<bool> HasPermissionAsync(int userId, string permission);
    Task<bool> IsInRoleAsync(int userId, string role);
    Task<IEnumerable<string>> GetUserPermissionsAsync(int userId);
    Task<IEnumerable<string>> GetUserRolesAsync(int userId);
    Task AssignRoleAsync(int userId, string role);
    Task RemoveRoleAsync(int userId, string role);
}