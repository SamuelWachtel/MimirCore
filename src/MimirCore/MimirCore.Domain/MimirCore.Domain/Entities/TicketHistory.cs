using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class TicketHistory : BaseEntity
{
    public int TicketId { get; set; }
    public int ChangedById { get; set; }

    [Required] [StringLength(100)] public string FieldName { get; set; }

    [StringLength(500)] public string OldValue { get; set; }

    [StringLength(500)] public string NewValue { get; set; }

    [StringLength(500)] public string ChangeDescription { get; set; }

    // Navigation properties
    public virtual Ticket Ticket { get; set; }
    public virtual Employee ChangedBy { get; set; }
}