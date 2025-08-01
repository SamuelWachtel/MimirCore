using System.ComponentModel.DataAnnotations;

namespace MimirCore.Domain.Entities;

public class TicketAttachment : BaseEntity
{
    public int TicketId { get; set; }
    public int UploadedById { get; set; }
        
    [Required]
    [StringLength(255)]
    public string FileName { get; set; }
        
    [Required]
    [StringLength(500)]
    public string FilePath { get; set; }
        
    [StringLength(100)]
    public string ContentType { get; set; }
        
    public long FileSize { get; set; }
        
    // Navigation properties
    public virtual Ticket Ticket { get; set; }
    public virtual Employee UploadedBy { get; set; }
}