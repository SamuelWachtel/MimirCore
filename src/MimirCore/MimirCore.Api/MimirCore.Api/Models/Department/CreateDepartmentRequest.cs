namespace MimirCore.Api.Models.Department;

public class CreateDepartmentRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int? ChiefId { get; set; }
}