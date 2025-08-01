using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Username { get; set; }
        
    [Required]
    [StringLength(255)]
    public string Email { get; set; }
        
    [StringLength(100)]
    public string FirstName { get; set; }
        
    [StringLength(100)]
    public string LastName { get; set; }
        
    [StringLength(15)]
    public string PhoneNumber { get; set; }
        
    public bool IsActive { get; set; } = true;
        
    public DateTime? LastLoginAt { get; set; }
        
    // Navigation properties
    public virtual Employee Employee { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}