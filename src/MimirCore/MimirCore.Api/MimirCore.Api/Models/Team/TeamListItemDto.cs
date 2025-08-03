namespace MimirCore.Api.Models.Team;

public class TeamListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DepartmentName { get; set; }
    public string? LeaderName { get; set; }
    public int MemberCount { get; set; }
}