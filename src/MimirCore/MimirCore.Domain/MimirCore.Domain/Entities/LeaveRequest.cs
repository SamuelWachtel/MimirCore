using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid LeaveTypeId { get; set; }
        
    [Required]
    public DateTime StartDate { get; set; }
        
    [Required]
    public DateTime EndDate { get; set; }
        
    public int TotalDays { get; set; }
        
    [StringLength(500)]
    public string Reason { get; set; }
        
    [StringLength(50)]
    public string Status { get; set; } = "Pending";
        
    public Guid? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
        
    [StringLength(500)]
    public string ApprovalComments { get; set; }
        
    public virtual Employee Employee { get; set; }
    public virtual LeaveType LeaveType { get; set; }
    public virtual Employee Approver { get; set; }
}