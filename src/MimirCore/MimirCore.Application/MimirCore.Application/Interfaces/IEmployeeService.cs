using MimirCore.Application.Models;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto> GetByIdAsync(int id);
    Task<EmployeeDto> GetByEmployeeNumberAsync(string employeeNumber);
    Task<IEnumerable<EmployeeDto>> GetByTeamAsync(int teamId);
    Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(int departmentId);
    Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto);
    Task UpdateAsync(UpdateEmployeeDto updateEmployeeDto);
    Task DeleteAsync(int id);
    Task TransferToTeamAsync(int employeeId, int newTeamId);
    Task PromoteToTeamLeaderAsync(int employeeId, int teamId);
    Task PromoteToDepartmentChiefAsync(int employeeId, int departmentId);
}