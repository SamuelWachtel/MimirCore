namespace MimirCore.Api.Models.Department;

public class UpdateDepartmentRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ChiefId { get; set; }
    
    public Guid ParentDepartmentId { get; set; }
}