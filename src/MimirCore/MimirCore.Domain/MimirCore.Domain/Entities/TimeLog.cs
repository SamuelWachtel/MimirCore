using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class TimeLog : BaseEntity
{
    public int EmployeeId { get; set; }
    public int? ShiftId { get; set; }
        
    [Required]
    public DateTime ClockIn { get; set; }
        
    public DateTime? ClockOut { get; set; }
        
    public int? TotalMinutes { get; set; }
        
    [StringLength(50)]
    public string LogType { get; set; } = "Regular";
        
    [StringLength(500)]
    public string Notes { get; set; }
        
    public virtual Employee Employee { get; set; }
    public virtual Shift Shift { get; set; }
}