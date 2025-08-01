namespace MimirCore.Application.Models.Shift;

// Shift ItemListDto - brief version for lists
public class ShiftItemListDto
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; }
    public string ShiftTemplateName { get; set; }
}