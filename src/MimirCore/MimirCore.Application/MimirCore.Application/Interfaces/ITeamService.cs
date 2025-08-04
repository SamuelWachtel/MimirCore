using MimirCore.Application.Models;
using MimirCore.Application.Models.Team;

namespace MimirCore.Application.Interfaces;

public interface ITeamService
{
    Task<TeamDto> GetByIdAsync(Guid id);
    Task<IEnumerable<TeamDto>> GetByDepartmentAsync(Guid departmentId);
    Task<IEnumerable<TeamDto>> GetAllAsync();
    Task<TeamDto> CreateAsync(CreateTeamDto createTeamDto);
    Task UpdateAsync(UpdateTeamDto updateTeamDto);
    Task DeleteAsync(Guid id);
    Task AssignLeaderAsync(Guid teamId, Guid employeeId);
    Task AddEmployeeAsync(Guid teamId, Guid employeeId);
    Task RemoveEmployeeAsync(Guid teamId, Guid employeeId);
}