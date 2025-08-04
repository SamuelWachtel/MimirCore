using MimirCore.Application.Models;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto> GetByIdAsync(Guid id);
    Task<EmployeeDto> GetByEmployeeNumberAsync(string employeeNumber);
    Task<IEnumerable<EmployeeDto>> GetByTeamAsync(Guid teamId);
    Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(Guid departmentId);
    Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto);
    Task UpdateAsync(UpdateEmployeeDto updateEmployeeDto);
    Task DeleteAsync(Guid id);
    Task TransferToTeamAsync(Guid employeeId, Guid newTeamId);
    Task PromoteToTeamLeaderAsync(Guid employeeId, Guid teamId);
    Task PromoteToDepartmentChiefAsync(Guid employeeId, Guid departmentId);
}