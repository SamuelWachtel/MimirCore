using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Ticket;

public class TicketDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public int CreatedById { get; set; }
    public int? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public TicketCategoryDto Category { get; set; }
    public EmployeeDto CreatedBy { get; set; }
    public EmployeeDto AssignedTo { get; set; }
    public ICollection<TicketCommentItemListDto> Comments { get; set; } = new List<TicketCommentItemListDto>();
    public ICollection<TicketAttachmentItemListDto> Attachments { get; set; } = new List<TicketAttachmentItemListDto>();
}

public class TicketCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class TicketCommentItemListDto
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public EmployeeItemListDto Author { get; set; }
}

public class TicketAttachmentItemListDto
{
    public int Id { get; set; }
    public int TicketId { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public string ContentType { get; set; }
    public long FileSize { get; set; }
    public int UploadedById { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Navigation properties
    public EmployeeItemListDto UploadedBy { get; set; }
}

public class CreateTicketDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; }
    public int CreatedById { get; set; }
    public int? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}

public class UpdateTicketDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public int? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}