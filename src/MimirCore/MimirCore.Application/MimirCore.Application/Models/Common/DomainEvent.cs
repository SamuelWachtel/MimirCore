namespace MimirCore.Application.Models.Common;

public abstract class DomainEvent
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;
}