namespace MimirCore.Application.Interfaces;

public interface IDateTime
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}