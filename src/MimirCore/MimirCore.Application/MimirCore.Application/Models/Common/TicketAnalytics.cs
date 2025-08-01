namespace MimirCore.Application.Models.Common;

public class TicketAnalytics
{
    public int TotalTickets { get; set; }
    public int OpenTickets { get; set; }
    public int ResolvedTickets { get; set; }
    public decimal AverageResolutionTime { get; set; }
    public Dictionary<string, int> TicketsByCategory { get; set; } = new();
    public Dictionary<string, int> TicketsByPriority { get; set; } = new();
}