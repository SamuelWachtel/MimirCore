using MimirCore.Application.Models.Position;
using MimirCore.Application.Models.Team;
using MimirCore.Application.Models.User;

namespace MimirCore.Application.Models.Employee;

public class EmployeeDto
{
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public int UserId { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties as DTOs
    public UserItemListDto User { get; set; }
    public TeamItemListDto Team { get; set; }
    public PositionItemListDto Position { get; set; }
}

public class CreateEmployeeDto
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

public class UpdateEmployeeDto
{
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public int TeamId { get; set; }
    public int PositionId { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentType { get; set; }
    public string Status { get; set; }
}