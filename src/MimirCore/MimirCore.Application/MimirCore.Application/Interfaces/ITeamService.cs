using MimirCore.Application.Models;
using MimirCore.Application.Models.Team;

namespace MimirCore.Application.Interfaces;

public interface ITeamService
{
    Task<TeamDto> GetByIdAsync(int id);
    Task<IEnumerable<TeamDto>> GetByDepartmentAsync(int departmentId);
    Task<IEnumerable<TeamDto>> GetAllAsync();
    Task<TeamDto> CreateAsync(CreateTeamDto createTeamDto);
    Task UpdateAsync(UpdateTeamDto updateTeamDto);
    Task DeleteAsync(int id);
    Task AssignLeaderAsync(int teamId, int employeeId);
    Task AddEmployeeAsync(int teamId, int employeeId);
    Task RemoveEmployeeAsync(int teamId, int employeeId);
}