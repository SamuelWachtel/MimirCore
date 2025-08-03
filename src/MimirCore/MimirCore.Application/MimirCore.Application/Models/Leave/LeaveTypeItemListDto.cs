namespace MimirCore.Application.Models.Leave;

public class LeaveTypeItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; }
}