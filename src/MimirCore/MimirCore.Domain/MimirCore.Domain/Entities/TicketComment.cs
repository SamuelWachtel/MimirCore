using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class TicketComment : BaseEntity
{
    public int TicketId { get; set; }
    public int AuthorId { get; set; }
        
    [Required]
    public string Content { get; set; }
        
    public bool IsInternal { get; set; } = false;
        
    public virtual Ticket Ticket { get; set; }
    public virtual Employee Author { get; set; }
}