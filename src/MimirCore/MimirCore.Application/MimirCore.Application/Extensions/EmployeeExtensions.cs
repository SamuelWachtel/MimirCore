using MimirCore.Application.Models.Employee;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class EmployeeExtensions
{
    // Domain -> Application
    public static EmployeeDto ToApplicationDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            EmployeeNumber = employee.EmployeeNumber,
            UserId = employee.UserId,
            TeamId = employee.TeamId,
            PositionId = employee.PositionId,
            HireDate = employee.HireDate,
            TerminationDate = employee.TerminationDate,
            Salary = employee.Salary,
            EmploymentType = employee.EmploymentType,
            Status = employee.Status,
            CreatedAt = employee.CreatedAt,
            UpdatedAt = employee.ModifiedAt,
            User = employee.User?.ToItemListDto(),
            Team = employee.Team?.ToItemListDto(),
            Position = employee.Position?.ToItemListDto()
        };
    }

    public static EmployeeItemListDto ToItemListDto(this Employee employee)
    {
        return new EmployeeItemListDto
        {
            Id = employee.Id,
            EmployeeNumber = employee.EmployeeNumber,
            FirstName = employee.User?.FirstName ?? "",
            LastName = employee.User?.LastName ?? "",
            Email = employee.User?.Email ?? "",
            TeamName = employee.Team?.Name ?? "",
            PositionTitle = employee.Position?.Title ?? "",
            Status = employee.Status,
            HireDate = employee.HireDate
        };
    }

    // Application -> Domain
    public static Employee ToEntity(this CreateEmployeeDto createEmployeeDto)
    {
        return new Employee
        {
            EmployeeNumber = createEmployeeDto.EmployeeNumber,
            UserId = createEmployeeDto.UserId,
            TeamId = createEmployeeDto.TeamId,
            PositionId = createEmployeeDto.PositionId,
            HireDate = createEmployeeDto.HireDate,
            Salary = createEmployeeDto.Salary,
            EmploymentType = createEmployeeDto.EmploymentType,
            Status = createEmployeeDto.Status,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateEmployeeDto updateEmployeeDto, Employee employee)
    {
        employee.EmployeeNumber = updateEmployeeDto.EmployeeNumber;
        employee.TeamId = updateEmployeeDto.TeamId;
        employee.PositionId = updateEmployeeDto.PositionId;
        employee.TerminationDate = updateEmployeeDto.TerminationDate;
        employee.Salary = updateEmployeeDto.Salary;
        employee.EmploymentType = updateEmployeeDto.EmploymentType;
        employee.Status = updateEmployeeDto.Status;
        employee.ModifiedAt = DateTime.UtcNow;
    }

    // Collection extensions
    public static IEnumerable<EmployeeDto> ToApplicationDtos(this IEnumerable<Employee> employees)
    {
        return employees.Select(e => e.ToApplicationDto());
    }

    public static IEnumerable<EmployeeItemListDto> ToItemListDtos(this IEnumerable<Employee> employees)
    {
        return employees.Select(e => e.ToItemListDto());
    }
}