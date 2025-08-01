using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Team : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
        
    [StringLength(500)]
    public string Description { get; set; }
        
    public int DepartmentId { get; set; }
        
    public int? TeamLeaderId { get; set; }
        
    // Navigation properties
    public virtual Department Department { get; set; }
    public virtual Employee TeamLeader { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}