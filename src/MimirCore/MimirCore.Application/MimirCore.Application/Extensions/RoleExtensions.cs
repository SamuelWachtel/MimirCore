using MimirCore.Application.Models.Permission;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class RoleExtensions
{
    // Domain -> Application
    public static RoleDto ToApplicationDto(this Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            CreatedAt = role.CreatedAt,
            UpdatedAt = role.ModifiedAt
        };
    }

    public static RoleItemListDto ToItemListDto(this Role role)
    {
        return new RoleItemListDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        };
    }

    // Collection extensions
    public static IEnumerable<RoleDto> ToApplicationDtos(this IEnumerable<Role> roles)
    {
        return roles.Select(r => r.ToApplicationDto());
    }

    public static IEnumerable<RoleItemListDto> ToItemListDtos(this IEnumerable<Role> roles)
    {
        return roles.Select(r => r.ToItemListDto());
    }
}