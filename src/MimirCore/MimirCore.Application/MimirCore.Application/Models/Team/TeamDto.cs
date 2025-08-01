using MimirCore.Application.Models.Department;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Team;

public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public int? LeaderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public DepartmentItemListDto Department { get; set; }
    public EmployeeItemListDto Leader { get; set; }
    public ICollection<EmployeeItemListDto> Members { get; set; } = new List<EmployeeItemListDto>();
}

public class CreateTeamDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public int? LeaderId { get; set; }
}

public class UpdateTeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DepartmentId { get; set; }
    public int? LeaderId { get; set; }
}