using MimirCore.Application.Models;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.Interfaces;

public interface ITicketService
{
    Task<TicketDto> GetByIdAsync(int id);
    Task<TicketDto> GetByTicketNumberAsync(string ticketNumber);
    Task<IEnumerable<TicketDto>> GetAssignedToUserAsync(int userId);
    Task<IEnumerable<TicketDto>> GetCreatedByUserAsync(int userId);
    Task<TicketDto> CreateAsync(CreateTicketDto createTicketDto);
    Task UpdateAsync(UpdateTicketDto updateTicketDto);
    Task AssignAsync(int ticketId, int assigneeId);
    Task AddCommentAsync(int ticketId, int authorId, string content, bool isInternal = false);
    Task AddAttachmentAsync(int ticketId, int uploadedById, string fileName, string filePath, string contentType, long fileSize);
    Task CloseAsync(int ticketId, string resolution);
    Task<string> GenerateTicketNumberAsync();
}