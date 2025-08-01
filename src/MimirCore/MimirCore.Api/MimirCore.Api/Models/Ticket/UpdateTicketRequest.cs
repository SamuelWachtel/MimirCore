namespace MimirCore.Api.Models.Ticket;

public class UpdateTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public int? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }
}