using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Shift;

public class ShiftDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public ShiftStatusDto Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public EmployeeItemListDto Employee { get; set; }
    public ShiftTemplateItemListDto ShiftTemplate { get; set; }
}

public class ShiftTemplateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateShiftDto
{
    public Guid EmployeeId { get; set; }
    public Guid? ShiftTemplateId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Notes { get; set; }
}

public class UpdateShiftDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public ShiftStatusDto StatusDto { get; set; }
    public string Notes { get; set; }
}