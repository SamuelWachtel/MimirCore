using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Queries.Ticket;

public class GetTicketByIdQuery : IQuery<TicketDto>
{
    public int Id { get; set; }
    public int UserId { get; set; } // For authorization
    
    public GetTicketByIdQuery(int id, int userId)
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