namespace MimirCore.Application.Models.Shift;

public class ShiftItemListDto
{
    public Guid Id { get; set; }
    public string EmployeeName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ShiftStatusDto Status { get; set; }
    public string ShiftTemplateName { get; set; }
}