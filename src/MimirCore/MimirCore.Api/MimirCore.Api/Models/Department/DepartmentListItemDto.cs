namespace MimirCore.Api.Models.Department;

public class DepartmentListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ChiefName { get; set; }
    public int TeamCount { get; set; }
    public int EmployeeCount { get; set; }
}