using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class LeaveType : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
        
    [StringLength(200)]
    public string Description { get; set; }
        
    public int MaxDaysPerYear { get; set; }
        
    public bool RequiresApproval { get; set; } = true;
        
    public bool IsPaid { get; set; } = true;
        
    // Navigation properties
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
}