using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Models.Ticket;

public class TicketDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public PriorityDto Priority { get; set; }
    public TicketStatusDto TicketStatus { get; set; }
    public Guid CreatedById { get; set; }
    public Guid? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public TicketCategoryDto Category { get; set; }
    public EmployeeDto CreatedBy { get; set; }
    public EmployeeDto AssignedTo { get; set; }
    public ICollection<TicketCommentItemListDto> Comments { get; set; } = new List<TicketCommentItemListDto>();
    public ICollection<TicketAttachmentItemListDto> Attachments { get; set; } = new List<TicketAttachmentItemListDto>();
}

public class TicketCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class TicketCommentItemListDto
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public EmployeeItemListDto Author { get; set; }
}

public class TicketAttachmentItemListDto
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public string ContentType { get; set; }
    public long FileSize { get; set; }
    public Guid UploadedById { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public EmployeeItemListDto UploadedBy { get; set; }
}

public class CreateTicketDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public PriorityDto Priority { get; set; }
    public Guid CreatedById { get; set; }
    public Guid? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}

public class UpdateTicketDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public PriorityDto Priority { get; set; }
    public TicketStatusDto TicketStatus { get; set; }
    public Guid? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}