namespace MimirCore.Api.Models.Ticket;

public class UpdateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public PriorityDto Priority { get; set; }
    public TicketStatusDto TicketStatus { get; set; }
    public Guid? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}