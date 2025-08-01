namespace MimirCore.Api.Models.Team;

public class TeamApiResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int? LeaderId { get; set; }
    public string? LeaderName { get; set; }
    public int MemberCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}