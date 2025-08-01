using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class TicketCategory : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
        
    [StringLength(500)]
    public string Description { get; set; }
        
    [StringLength(50)]
    public string Color { get; set; }
        
    public int? ParentCategoryId { get; set; }
        
    // Navigation properties
    public virtual TicketCategory ParentCategory { get; set; }
    public virtual ICollection<TicketCategory> SubCategories { get; set; } = new List<TicketCategory>();
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}