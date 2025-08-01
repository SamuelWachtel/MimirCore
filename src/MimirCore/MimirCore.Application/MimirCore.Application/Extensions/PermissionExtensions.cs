using MimirCore.Application.Models.Permission;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class PermissionExtensions
{
    // Domain -> Application
    public static PermissionDto ToApplicationDto(this Permission permission)
    {
        return new PermissionDto
        {
            Id = permission.Id,
            Name = permission.Name,
            Description = permission.Description,
            Category = permission.Module,
            CreatedAt = permission.CreatedAt,
            UpdatedAt = permission.ModifiedAt
        };
    }

    public static PermissionItemListDto ToItemListDto(this Permission permission)
    {
        return new PermissionItemListDto
        {
            Id = permission.Id,
            Name = permission.Name,
            Description = permission.Description,
            Category = permission.Module
        };
    }

    // Collection extensions
    public static IEnumerable<PermissionDto> ToApplicationDtos(this IEnumerable<Permission> permissions)
    {
        return permissions.Select(p => p.ToApplicationDto());
    }

    public static IEnumerable<PermissionItemListDto> ToItemListDtos(this IEnumerable<Permission> permissions)
    {
        return permissions.Select(p => p.ToItemListDto());
    }
}