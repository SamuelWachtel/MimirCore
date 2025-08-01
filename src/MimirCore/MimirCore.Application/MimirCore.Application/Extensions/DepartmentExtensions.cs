using MimirCore.Application.Models.Department;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class DepartmentExtensions
{
    // Domain -> Application
    public static DepartmentDto ToApplicationDto(this Department department)
    {
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ChiefId = department.DepartmentChiefId,
            CreatedAt = department.CreatedAt,
            UpdatedAt = department.ModifiedAt,
            Chief = department.DepartmentChief?.ToItemListDto(),
            Teams = department.Teams?.ToItemListDtos().ToList() ?? new List<MimirCore.Application.Models.Team.TeamItemListDto>()
        };
    }

    public static DepartmentItemListDto ToItemListDto(this Department department)
    {
        return new DepartmentItemListDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ChiefName = department.DepartmentChief != null ? $"{department.DepartmentChief.User?.FirstName} {department.DepartmentChief.User?.LastName}" : null,
            TeamCount = department.Teams?.Count ?? 0,
            EmployeeCount = department.Teams?.Sum(t => t.Employees?.Count ?? 0) ?? 0
        };
    }

    // Application -> Domain
    public static Department ToEntity(this CreateDepartmentDto createDepartmentDto)
    {
        return new Department
        {
            Name = createDepartmentDto.Name,
            Description = createDepartmentDto.Description,
            DepartmentChiefId = createDepartmentDto.ChiefId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateDepartmentDto updateDepartmentDto, Department department)
    {
        department.Name = updateDepartmentDto.Name;
        department.Description = updateDepartmentDto.Description;
        department.DepartmentChiefId = updateDepartmentDto.ChiefId;
        department.ModifiedAt = DateTime.UtcNow;
    }

    // Collection extensions
    public static IEnumerable<DepartmentDto> ToApplicationDtos(this IEnumerable<Department> departments)
    {
        return departments.Select(d => d.ToApplicationDto());
    }

    public static IEnumerable<DepartmentItemListDto> ToItemListDtos(this IEnumerable<Department> departments)
    {
        return departments.Select(d => d.ToItemListDto());
    }
}