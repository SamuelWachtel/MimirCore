using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Commands.Ticket;

public class UpdateTicketCommand : ICommand<TicketDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public PriorityDto Priority { get; set; }
    public Guid UserId { get; set; }
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