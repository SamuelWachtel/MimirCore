using MimirCore.Api.Models.Department;
using MimirCore.Application.Models.Department;
using DepartmentPaginatedListResponse = MimirCore.Api.Models.Department.DepartmentPaginatedListResponse;

namespace MimirCore.Api.Extensions;

public static class DepartmentApiExtensions
{
    // Application -> API
    public static DepartmentResponse ToApiDto(this DepartmentDto departmentDto)
    {
        return new DepartmentResponse
        {
            Id = departmentDto.Id,
            Name = departmentDto.Name,
            Description = departmentDto.Description,
            ChiefId = departmentDto.ChiefId,
            CreatedAt = departmentDto.CreatedAt,
            UpdatedAt = departmentDto.UpdatedAt,
            ChiefName = departmentDto.Chief != null ? $"{departmentDto.Chief.FirstName} {departmentDto.Chief.LastName}" : null,
            TeamCount = departmentDto.Teams?.Count ?? 0
        };
    }

    public static DepartmentListItemDto ToApiDto(this Application.Models.Department.DepartmentItemListDto departmentItemDto)
    {
        return new DepartmentListItemDto
        {
            Id = departmentItemDto.Id,
            Name = departmentItemDto.Name,
            Description = departmentItemDto.Description,
            ChiefName = departmentItemDto.ChiefName,
            TeamCount = departmentItemDto.TeamCount,
            EmployeeCount = departmentItemDto.EmployeeCount
        };
    }

    // API -> Application
    public static CreateDepartmentDto ToApplicationDto(this CreateDepartmentRequest createDepartmentRequest)
    {
        return new CreateDepartmentDto
        {
            Name = createDepartmentRequest.Name,
            Description = createDepartmentRequest.Description,
            ChiefId = createDepartmentRequest.ChiefId
        };
    }

    public static UpdateDepartmentDto ToApplicationDto(this UpdateDepartmentRequest updateDepartmentRequest)
    {
        return new UpdateDepartmentDto
        {
            Name = updateDepartmentRequest.Name,
            Description = updateDepartmentRequest.Description,
            ChiefId = updateDepartmentRequest.ChiefId
        };
    }

    // Collection extensions
    public static IEnumerable<DepartmentResponse> ToApiDtos(this IEnumerable<DepartmentDto> departments)
    {
        return departments.Select(d => d.ToApiDto());
    }

    public static IEnumerable<DepartmentListItemDto> ToApiDtos(this IEnumerable<Application.Models.Department.DepartmentItemListDto> departments)
    {
        return departments.Select(d => d.ToApiDto());
    }

    // Pagination extensions
    public static DepartmentPaginatedListResponse ToApiResponse(this Application.Models.Department.DepartmentPaginatedListResponse appResponse)
    {
        return new DepartmentPaginatedListResponse(
            appResponse.Items.ToApiDtos().ToList(),
            appResponse.PageNumber,
            appResponse.PageSize,
            appResponse.TotalCount
        );
    }
}