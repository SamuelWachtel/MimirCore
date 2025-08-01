using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Commands.Ticket;

public class UpdateTicketCommand : ICommand<TicketDto>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; }
    public int UserId { get; set; } // For authorization
}

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, TicketDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}