namespace MimirCore.Api.Models.Ticket;

public class TicketResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public PriorityDto Priority { get; set; }
    public TicketStatusDto TicketStatus { get; set; }
    public Guid CreatedById { get; set; }
    public string CreatedByName { get; set; }
    public Guid? AssignedToId { get; set; }
    public string? AssignedToName { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}