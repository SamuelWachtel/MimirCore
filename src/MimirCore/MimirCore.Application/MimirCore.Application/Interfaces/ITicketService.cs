using MimirCore.Application.Models;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.Interfaces;

public interface ITicketService
{
    Task<TicketDto> GetByIdAsync(Guid id);
    Task<TicketDto> GetByTicketNumberAsync(string ticketNumber);
    Task<IEnumerable<TicketDto>> GetAssignedToUserAsync(Guid userId);
    Task<IEnumerable<TicketDto>> GetCreatedByUserAsync(Guid userId);
    Task<TicketDto> CreateAsync(CreateTicketDto createTicketDto);
    Task UpdateAsync(UpdateTicketDto updateTicketDto);
    Task AssignAsync(Guid ticketId, Guid assigneeId);
    Task AddCommentAsync(Guid ticketId, Guid authorId, string content, bool isInternal = false);
    Task AddAttachmentAsync(Guid ticketId, Guid uploadedById, string fileName, string filePath, string contentType, long fileSize);
    Task CloseAsync(Guid ticketId, string resolution);
    Task<string> GenerateTicketNumberAsync();
}