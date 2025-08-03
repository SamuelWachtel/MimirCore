namespace MimirCore.Api.Models.Employee;

public class UpdateEmployeeRequest
{
    public string EmployeeNumber { get; set; }
    public Guid TeamId { get; set; }
    public Guid PositionId { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
}