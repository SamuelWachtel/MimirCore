using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class ShiftTemplate : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
        
    [Required]
    public TimeSpan StartTime { get; set; }
        
    [Required]
    public TimeSpan EndTime { get; set; }
        
    public int DurationMinutes { get; set; }
        
    [StringLength(200)]
    public string Description { get; set; }
        
    [StringLength(50)]
    public string ShiftType { get; set; } // Morning, Evening, Night, Rotating
        
    // Navigation properties
    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}