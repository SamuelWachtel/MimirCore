namespace MimirCore.Application.Models.Department;

public class DepartmentItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ChiefName { get; set; }
    public int TeamCount { get; set; }
    public int EmployeeCount { get; set; }
}