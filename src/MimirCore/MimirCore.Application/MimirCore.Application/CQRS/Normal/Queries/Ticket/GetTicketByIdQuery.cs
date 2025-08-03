using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Queries.Ticket;

public class GetTicketByIdQuery : IQuery<TicketDto>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public GetTicketByIdQuery(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
}

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    private readonly IApplicationDbContext _context;

    public GetTicketByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}