namespace MimirCore.Application.Models.Ticket;

public class TicketItemListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CategoryName { get; set; }
    public PriorityDto Priority { get; set; }
    public TicketStatusDto TicketStatus { get; set; }
    public string CreatedByName { get; set; }
    public string AssignedToName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
}