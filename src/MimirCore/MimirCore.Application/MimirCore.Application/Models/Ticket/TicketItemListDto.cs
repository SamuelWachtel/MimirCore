namespace MimirCore.Application.Models.Ticket;

// Ticket ItemListDto - brief version for lists
public class TicketItemListDto
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