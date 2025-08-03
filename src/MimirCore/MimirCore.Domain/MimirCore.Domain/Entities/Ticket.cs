using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class Ticket : BaseEntity
{
    [Required]
    [StringLength(20)]
    public string TicketNumber { get; set; }
        
    [Required]
    [StringLength(200)]
    public string Title { get; set; }
        
    [Required]
    public string Description { get; set; }
        
    public Guid CategoryId { get; set; }
    public Guid CreatedById { get; set; }
    public Guid? AssignedToId { get; set; }

    public Priority Priority { get; set; } = Priority.Low;
        
    public TicketStatus TicketStatus { get; set; } = TicketStatus.New;
        
    public DateTime? DueDate { get; set; }
    public DateTime? ResolvedAt { get; set; }
        
    [StringLength(500)]
    public string Resolution { get; set; }
        
    public virtual TicketCategory Category { get; set; }
    public virtual Employee CreatedBy { get; set; }
    public virtual Employee AssignedTo { get; set; }
    public virtual ICollection<TicketComment> Comments { get; set; } = new List<TicketComment>();
    public virtual ICollection<TicketAttachment> Attachments { get; set; } = new List<TicketAttachment>();
    public virtual ICollection<TicketHistory> History { get; set; } = new List<TicketHistory>();
}