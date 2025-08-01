namespace MimirCore.Api.Models.Team;

public class UpdateTeamRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public int? LeaderId { get; set; }
}