using MimirCore.Application.Models.Team;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.Extensions;

public static class TeamExtensions
{
    public static TeamDto ToApplicationDto(this Team team)
    {
        return new TeamDto
        {
            Id = team.Id,
            Name = team.Name,
            Description = team.Description,
            DepartmentId = team.DepartmentId,
            LeaderId = team.TeamLeaderId,
            CreatedAt = team.CreatedAt,
            UpdatedAt = team.ModifiedAt,
            Department = team.Department?.ToItemListDto(),
            Leader = team.TeamLeader?.ToItemListDto(),
            Members = team.Employees?.ToItemListDtos().ToList() ?? new List<MimirCore.Application.Models.Employee.EmployeeItemListDto>()
        };
    }

    public static TeamItemListDto ToItemListDto(this Team team)
    {
        return new TeamItemListDto
        {
            Id = team.Id,
            Name = team.Name,
            Description = team.Description,
            DepartmentName = team.Department?.Name ?? "",
            LeaderName = team.TeamLeader != null ? $"{team.TeamLeader.User?.FirstName} {team.TeamLeader.User?.LastName}" : null,
            MemberCount = team.Employees?.Count ?? 0
        };
    }

    public static Team ToEntity(this CreateTeamDto createTeamDto)
    {
        return new Team
        {
            Name = createTeamDto.Name,
            Description = createTeamDto.Description,
            DepartmentId = createTeamDto.DepartmentId,
            TeamLeaderId = createTeamDto.LeaderId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static void UpdateEntity(this UpdateTeamDto updateTeamDto, Team team)
    {
        team.Name = updateTeamDto.Name;
        team.Description = updateTeamDto.Description;
        team.DepartmentId = updateTeamDto.DepartmentId;
        team.TeamLeaderId = updateTeamDto.LeaderId;
        team.ModifiedAt = DateTime.UtcNow;
    }

    public static IEnumerable<TeamDto> ToApplicationDtos(this IEnumerable<Team> teams)
    {
        return teams.Select(t => t.ToApplicationDto());
    }

    public static IEnumerable<TeamItemListDto> ToItemListDtos(this IEnumerable<Team> teams)
    {
        return teams.Select(t => t.ToItemListDto());
    }
}