namespace MimirCore.Application.Models.Common;

public class AuditLog
{
    public Guid Id { get; set; }
    public string EntityName { get; set; }
    public Guid EntityId { get; set; }
    public string Action { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public Guid UserId { get; set; }
    public DateTime Timestamp { get; set; }
}