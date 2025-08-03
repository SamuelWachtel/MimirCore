namespace MimirCore.Application.Models.Team;

public class TeamItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DepartmentName { get; set; }
    public string LeaderName { get; set; }
    public int MemberCount { get; set; }
}