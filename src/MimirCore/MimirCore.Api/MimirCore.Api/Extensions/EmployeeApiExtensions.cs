using MimirCore.Api.Models.Employee;
using MimirCore.Application.Models.Employee;
using EmployeePaginatedListResponse = MimirCore.Api.Models.Employee.EmployeePaginatedListResponse;

namespace MimirCore.Api.Extensions;

public static class EmployeeApiExtensions
{
    public static EmployeeResponse ToApiDto(this EmployeeDto employeeDto)
    {
        return new EmployeeResponse
        {
            Id = employeeDto.Id,
            EmployeeNumber = employeeDto.EmployeeNumber,
            UserId = employeeDto.UserId,
            TeamId = employeeDto.TeamId,
            PositionId = employeeDto.PositionId,
            HireDate = employeeDto.HireDate,
            TerminationDate = employeeDto.TerminationDate,
            Salary = employeeDto.Salary,
            EmploymentType = employeeDto.EmploymentType,
            Status = employeeDto.Status,
            CreatedAt = employeeDto.CreatedAt,
            UpdatedAt = employeeDto.UpdatedAt,
            UserName = employeeDto.User != null ? $"{employeeDto.User.FirstName} {employeeDto.User.LastName}" : null,
            TeamName = employeeDto.Team?.Name,
            PositionTitle = employeeDto.Position?.Title
        };
    }

    public static EmployeeListItemDto ToApiDto(this EmployeeItemListDto employeeItemDto)
    {
        return new EmployeeListItemDto
        {
            Id = employeeItemDto.Id,
            EmployeeNumber = employeeItemDto.EmployeeNumber,
            FirstName = employeeItemDto.FirstName,
            LastName = employeeItemDto.LastName,
            Email = employeeItemDto.Email,
            TeamName = employeeItemDto.TeamName,
            PositionTitle = employeeItemDto.PositionTitle,
            Status = employeeItemDto.Status,
            HireDate = employeeItemDto.HireDate
        };
    }

    public static CreateEmployeeDto ToApplicationDto(this CreateEmployeeRequest createEmployeeRequest)
    {
        return new CreateEmployeeDto
        {
            EmployeeNumber = createEmployeeRequest.EmployeeNumber,
            UserId = createEmployeeRequest.UserId,
            TeamId = createEmployeeRequest.TeamId,
            PositionId = createEmployeeRequest.PositionId,
            HireDate = createEmployeeRequest.HireDate,
            Salary = createEmployeeRequest.Salary,
            EmploymentType = createEmployeeRequest.EmploymentType,
            Status = createEmployeeRequest.Status
        };
    }

    public static UpdateEmployeeDto ToApplicationDto(this UpdateEmployeeRequest updateEmployeeRequest)
    {
        return new UpdateEmployeeDto
        {
            EmployeeNumber = updateEmployeeRequest.EmployeeNumber,
            TeamId = updateEmployeeRequest.TeamId,
            PositionId = updateEmployeeRequest.PositionId,
            TerminationDate = updateEmployeeRequest.TerminationDate,
            Salary = updateEmployeeRequest.Salary,
            EmploymentType = updateEmployeeRequest.EmploymentType,
            Status = updateEmployeeRequest.Status
        };
    }

    public static IEnumerable<EmployeeResponse> ToApiDtos(this IEnumerable<EmployeeDto> employees)
    {
        return employees.Select(e => e.ToApiDto());
    }

    public static IEnumerable<EmployeeListItemDto> ToApiDtos(this IEnumerable<EmployeeItemListDto> employees)
    {
        return employees.Select(e => e.ToApiDto());
    }

    public static EmployeePaginatedListResponse ToApiResponse(this Application.Models.Employee.EmployeePaginatedListResponse appResponse)
    {
        return new EmployeePaginatedListResponse(
            appResponse.Items.ToApiDtos().ToList(),
            appResponse.PageNumber,
            appResponse.PageSize,
            appResponse.TotalCount
        );
    }
}