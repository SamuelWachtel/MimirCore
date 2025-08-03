namespace MimirCore.Api.Models.Department;

public class DepartmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ChiefId { get; set; }
    public string? ChiefName { get; set; }
    public int TeamCount { get; set; }
    public int EmployeeCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}