namespace MimirCore.Api.Models.Employee;

public class CreateEmployeeRequest
{
    public string EmployeeNumber { get; set; }
    public int UserId { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
}