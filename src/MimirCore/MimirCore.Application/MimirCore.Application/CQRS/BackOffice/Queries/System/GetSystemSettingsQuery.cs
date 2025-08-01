using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Domain.Entities;

namespace MimirCore.Application.CQRS.BackOffice.Queries.System;

public class GetSystemSettingsQuery : IQuery<IEnumerable<SystemSetting>>
{
    public string? Category { get; set; }
}

public class GetSystemSettingsQueryHandler : IRequestHandler<GetSystemSettingsQuery, IEnumerable<SystemSetting>>
{
    private readonly IApplicationDbContext _context;

    public GetSystemSettingsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SystemSetting>> Handle(GetSystemSettingsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}