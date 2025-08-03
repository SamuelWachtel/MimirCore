namespace MimirCore.Application.Models.Leave;

public class LeaveRequestItemListDto
{
    public Guid Id { get; set; }
    public string EmployeeName { get; set; }
    public string LeaveTypeName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DaysRequested { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}