namespace MimirCore.Api.Models.Employee;

public class EmployeeResponse
{
    public Guid Id { get; set; }
    public string EmployeeNumber { get; set; }
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PositionId { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string? UserName { get; set; }
    public string? TeamName { get; set; }
    public string? PositionTitle { get; set; }
}