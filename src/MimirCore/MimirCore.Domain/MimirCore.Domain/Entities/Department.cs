using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Department : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
        
    [StringLength(500)]
    public string Description { get; set; }
        
    public Guid? ParentDepartmentId { get; set; }
        
    public Guid? DepartmentChiefId { get; set; }
        
    public virtual Department ParentDepartment { get; set; }
    public virtual ICollection<Department> SubDepartments { get; set; } = new List<Department>();
    public virtual Employee DepartmentChief { get; set; }
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}