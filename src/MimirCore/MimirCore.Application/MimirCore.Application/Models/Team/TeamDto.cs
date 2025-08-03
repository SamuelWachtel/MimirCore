using MimirCore.Application.Models.Department;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Team;

public class TeamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? LeaderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public DepartmentItemListDto Department { get; set; }
    public EmployeeItemListDto Leader { get; set; }
    public ICollection<EmployeeItemListDto> Members { get; set; } = new List<EmployeeItemListDto>();
}

public class CreateTeamDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? LeaderId { get; set; }
}

public class UpdateTeamDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid? LeaderId { get; set; }
}