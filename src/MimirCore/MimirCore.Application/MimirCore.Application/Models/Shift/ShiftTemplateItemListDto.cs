namespace MimirCore.Application.Models.Shift;

public class ShiftTemplateItemListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}