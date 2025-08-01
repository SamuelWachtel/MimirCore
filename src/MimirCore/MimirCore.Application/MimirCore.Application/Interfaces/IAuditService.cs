using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;

namespace MimirCore.Application.Interfaces;

public interface IAuditService
{
    Task LogActivityAsync(string entityName, string entityId, string action, string? oldValues = null, string? newValues = null);
    Task<IEnumerable<AuditLog>> GetAuditLogAsync(string entityName, string entityId);
}