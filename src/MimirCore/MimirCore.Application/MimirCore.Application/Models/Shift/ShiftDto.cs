using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Shift;

public class ShiftDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public EmployeeItemListDto Employee { get; set; }
    public ShiftTemplateItemListDto ShiftTemplate { get; set; }
}

public class ShiftTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateShiftDto
{
    public int EmployeeId { get; set; }
    public int? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Notes { get; set; }
}

public class UpdateShiftDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}