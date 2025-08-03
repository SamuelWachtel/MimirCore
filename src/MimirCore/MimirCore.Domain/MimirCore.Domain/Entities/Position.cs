using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MimirCore.Domain.Entities;

public class Position : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
        
    [StringLength(500)]
    public string Description { get; set; }
        
    public Guid DepartmentId { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal? MinSalary { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal? MaxSalary { get; set; }
        
    public virtual Department Department { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}