namespace MimirCore.Application.Models.Leave;

// Leave Type ItemListDto - brief version for lists
public class LeaveTypeItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; }
}