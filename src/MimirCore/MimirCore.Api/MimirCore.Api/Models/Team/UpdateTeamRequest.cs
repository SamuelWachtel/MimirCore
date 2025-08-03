namespace MimirCore.Api.Models.Team;

public class UpdateTeamRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? LeaderId { get; set; }
}