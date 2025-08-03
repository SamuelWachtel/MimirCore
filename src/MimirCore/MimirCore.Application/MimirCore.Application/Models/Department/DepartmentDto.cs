using MimirCore.Application.Models.Employee;
using MimirCore.Application.Models.Team;

namespace MimirCore.Application.Models.Department;

public class DepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ChiefId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public EmployeeItemListDto Chief { get; set; }
    public ICollection<TeamItemListDto> Teams { get; set; } = new List<TeamItemListDto>();
}

public class CreateDepartmentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ChiefId { get; set; }
}

public class UpdateDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ChiefId { get; set; }
}