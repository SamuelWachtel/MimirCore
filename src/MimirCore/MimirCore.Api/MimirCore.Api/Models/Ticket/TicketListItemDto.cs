namespace MimirCore.Api.Models.Ticket;

// Ticket ItemListApiDto - brief version for API lists
public class TicketListItemDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CategoryName { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string CreatedByName { get; set; }
    public string AssignedToName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
}