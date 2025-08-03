using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.Ticket;

namespace MimirCore.Application.CQRS.Normal.Queries.Ticket;

public class GetMyTicketsQuery : IQuery<TicketPaginatedListResponse>
{
    public Guid UserId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Status { get; set; }
    public string? Priority { get; set; }
}

public class GetMyTicketsQueryHandler : IRequestHandler<GetMyTicketsQuery, TicketPaginatedListResponse>
{
    private readonly IApplicationDbContext _context;

    public GetMyTicketsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TicketPaginatedListResponse> Handle(GetMyTicketsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}