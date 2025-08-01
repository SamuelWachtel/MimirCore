using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Interfaces;

public interface IDomainEventService
{
    Task PublishAsync(DomainEvent domainEvent);
}