namespace MimirCore.Api.Models.Employee;

public class UpdateEmployeeRequest
{
    public string EmployeeNumber { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
}