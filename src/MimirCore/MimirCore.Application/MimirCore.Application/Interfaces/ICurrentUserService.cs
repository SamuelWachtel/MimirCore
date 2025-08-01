namespace MimirCore.Application.Interfaces;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? Username { get; }
    bool IsAuthenticated { get; }
    Task<bool> IsInRoleAsync(string role);
    Task<bool> HasPermissionAsync(string permission);
}