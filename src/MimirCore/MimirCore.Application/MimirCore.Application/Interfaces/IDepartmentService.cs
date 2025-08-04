using MimirCore.Application.Models;
using MimirCore.Application.Models.Department;

namespace MimirCore.Application.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDto> GetByIdAsync(Guid id);
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
    Task<IEnumerable<DepartmentDto>> GetHierarchyAsync();
    Task<DepartmentDto> CreateAsync(CreateDepartmentDto createDepartmentDto);
    Task UpdateAsync(UpdateDepartmentDto updateDepartmentDto);
    Task DeleteAsync(Guid id);
    Task AssignChiefAsync(Guid departmentId, Guid employeeId);
}