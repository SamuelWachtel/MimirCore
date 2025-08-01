namespace MimirCore.Application.Models.Team;

// Team ItemListDto - brief version for lists
public class TeamItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DepartmentName { get; set; }
    public string LeaderName { get; set; }
    public int MemberCount { get; set; }
}