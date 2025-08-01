namespace MimirCore.Application.Models.Leave;

// Leave Request ItemListDto - brief version for lists
public class LeaveRequestItemListDto
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public string LeaveTypeName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysRequested { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}