using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Shift : BaseEntity
{
    public int EmployeeId { get; set; }
    public int ShiftTemplateId { get; set; }
        
    [Required]
    public DateTime ShiftDate { get; set; }
        
    [Required]
    public DateTime StartTime { get; set; }
        
    [Required]
    public DateTime EndTime { get; set; }
        
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
        
    [StringLength(50)]
    public string Status { get; set; } = "Scheduled"; // Scheduled, InProgress, Completed, Cancelled
        
    [StringLength(500)]
    public string Notes { get; set; }
        
    // Navigation properties
    public virtual Employee Employee { get; set; }
    public virtual ShiftTemplate ShiftTemplate { get; set; }
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}