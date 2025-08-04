namespace MimirCore.Api.Models.Leave;

public class CreateLeaveTypeRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public bool RequiresApproval { get; set; } = true;
}