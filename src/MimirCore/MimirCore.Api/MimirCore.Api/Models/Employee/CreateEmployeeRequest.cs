namespace MimirCore.Api.Models.Employee;

public class CreateEmployeeRequest
{
    public string EmployeeNumber { get; set; }
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PositionId { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
}