namespace MimirCore.Application.Models.Common;

public class AuditLog
{
    public int Id { get; set; }
    public string EntityName { get; set; }
    public string EntityId { get; set; }
    public string Action { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string UserId { get; set; }
    public DateTime Timestamp { get; set; }
}