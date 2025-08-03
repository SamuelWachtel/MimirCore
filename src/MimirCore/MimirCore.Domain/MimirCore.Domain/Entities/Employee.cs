using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimirCore.Domain.Entities;

public class Employee : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string EmployeeNumber { get; set; }
        
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public Guid PositionId { get; set; }
        
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
        
    [StringLength(50)]
    public string EmploymentType { get; set; }
        
    [StringLength(50)]
    public string Status { get; set; }
        
    public virtual User User { get; set; }
    public virtual Team Team { get; set; }
    public virtual Position Position { get; set; }
    public virtual ICollection<Department> LedDepartments { get; set; } = new List<Department>();
    public virtual ICollection<Team> LedTeams { get; set; } = new List<Team>();
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    public virtual ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    public virtual ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
}