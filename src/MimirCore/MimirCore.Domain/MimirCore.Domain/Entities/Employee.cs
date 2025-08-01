using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimirCore.Domain.Entities;

public class Employee : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string EmployeeNumber { get; set; }
        
    public int UserId { get; set; }
    public int TeamId { get; set; } // CHANGED from DepartmentId
    public int PositionId { get; set; }
        
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
        
    [StringLength(50)]
    public string EmploymentType { get; set; } // Full-time, Part-time, Contract
        
    [StringLength(50)]
    public string Status { get; set; } // Active, Inactive, Terminated
        
    // REMOVED: ManagerId and Manager/DirectReports relationships
        
    // Navigation properties
    public virtual User User { get; set; }
    public virtual Team Team { get; set; } // CHANGED from Department
    public virtual Position Position { get; set; }
    public virtual ICollection<Department> LedDepartments { get; set; } = new List<Department>(); // NEW
    public virtual ICollection<Team> LedTeams { get; set; } = new List<Team>(); // NEW
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    public virtual ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    public virtual ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
}