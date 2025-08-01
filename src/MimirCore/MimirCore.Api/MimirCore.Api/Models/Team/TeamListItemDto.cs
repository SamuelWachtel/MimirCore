namespace MimirCore.Api.Models.Team;

// Team ItemListApiDto - brief version for API lists
public class TeamListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DepartmentName { get; set; }
    public string? LeaderName { get; set; }
    public int MemberCount { get; set; }
}