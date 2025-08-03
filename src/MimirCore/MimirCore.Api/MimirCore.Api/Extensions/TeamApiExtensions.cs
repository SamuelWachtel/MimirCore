using MimirCore.Api.Models.Team;
using MimirCore.Application.Models.Team;
using TeamPaginatedListResponse = MimirCore.Api.Models.Team.TeamPaginatedListResponse;

namespace MimirCore.Api.Extensions;

public static class TeamApiExtensions
{
    public static TeamApiResponse ToApiDto(this TeamDto teamDto)
    {
        return new TeamApiResponse
        {
            Id = teamDto.Id,
            Name = teamDto.Name,
            Description = teamDto.Description,
            DepartmentId = teamDto.DepartmentId,
            LeaderId = teamDto.LeaderId,
            CreatedAt = teamDto.CreatedAt,
            UpdatedAt = teamDto.UpdatedAt,
            DepartmentName = teamDto.Department?.Name,
            LeaderName = teamDto.Leader != null ? $"{teamDto.Leader.FirstName} {teamDto.Leader.LastName}" : null,
            MemberCount = teamDto.Members?.Count ?? 0
        };
    }

    public static TeamListItemDto ToApiDto(this TeamItemListDto teamItemDto)
    {
        return new TeamListItemDto
        {
            Id = teamItemDto.Id,
            Name = teamItemDto.Name,
            Description = teamItemDto.Description,
            DepartmentName = teamItemDto.DepartmentName,
            LeaderName = teamItemDto.LeaderName,
            MemberCount = teamItemDto.MemberCount
        };
    }

    public static CreateTeamDto ToApplicationDto(this CreateTeamRequest createTeamRequest)
    {
        return new CreateTeamDto
        {
            Name = createTeamRequest.Name,
            Description = createTeamRequest.Description,
            DepartmentId = createTeamRequest.DepartmentId,
            LeaderId = createTeamRequest.LeaderId
        };
    }

    public static UpdateTeamDto ToApplicationDto(this UpdateTeamRequest updateTeamRequest)
    {
        return new UpdateTeamDto
        {
            Name = updateTeamRequest.Name,
            Description = updateTeamRequest.Description,
            DepartmentId = updateTeamRequest.DepartmentId,
            LeaderId = updateTeamRequest.LeaderId
        };
    }

    public static IEnumerable<TeamApiResponse> ToApiDtos(this IEnumerable<TeamDto> teams)
    {
        return teams.Select(t => t.ToApiDto());
    }

    public static IEnumerable<TeamListItemDto> ToApiDtos(this IEnumerable<TeamItemListDto> teams)
    {
        return teams.Select(t => t.ToApiDto());
    }

    public static TeamPaginatedListResponse ToApiResponse(this Application.Models.Team.TeamPaginatedListResponse appResponse)
    {
        return new TeamPaginatedListResponse(
            appResponse.Items.ToApiDtos().ToList(),
            appResponse.PageNumber,
            appResponse.PageSize,
            appResponse.TotalCount
        );
    }
}