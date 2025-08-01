using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Commands.Ticket;

public class CreateTicketCommand : ICommand<TicketDto>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Priority { get; set; } = "Medium";
    public int CreatedById { get; set; }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, TicketDto>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketDto> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}