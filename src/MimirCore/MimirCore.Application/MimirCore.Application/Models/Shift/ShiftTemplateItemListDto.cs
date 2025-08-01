namespace MimirCore.Application.Models.Shift;

// Shift Template ItemListDto - brief version for lists
public class ShiftTemplateItemListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}