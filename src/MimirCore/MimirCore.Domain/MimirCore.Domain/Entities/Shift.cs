using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Shift : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid ShiftTemplateId { get; set; }
        
    [Required]
    public DateTime ShiftDate { get; set; }
        
    [Required]
    public DateTime StartTime { get; set; }
        
    [Required]
    public DateTime EndTime { get; set; }
        
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }

    public ShiftStatus Status { get; set; } = ShiftStatus.Scheduled;
        
    [StringLength(500)]
    public string Notes { get; set; }
        
    public virtual Employee Employee { get; set; }
    public virtual ShiftTemplate ShiftTemplate { get; set; }
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}