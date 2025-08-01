namespace MimirCore.Application.Models.Employee;

// Employee ItemListDto - brief version for lists
public class EmployeeItemListDto
{
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TeamName { get; set; }
    public string PositionTitle { get; set; }
    public string Status { get; set; }
    public DateTime HireDate { get; set; }
}