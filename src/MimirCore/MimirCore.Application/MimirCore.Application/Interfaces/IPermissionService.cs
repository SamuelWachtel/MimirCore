using MimirCore.Application.Models;
using MimirCore.Application.Models.Permission;

namespace MimirCore.Application.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllAsync();
    Task<IEnumerable<PermissionDto>> GetByModuleAsync(string module);
    Task<IEnumerable<PermissionDto>> GetByRoleAsync(int roleId);
    Task AssignPermissionToRoleAsync(int roleId, int permissionId);
    Task RemovePermissionFromRoleAsync(int roleId, int permissionId);
}