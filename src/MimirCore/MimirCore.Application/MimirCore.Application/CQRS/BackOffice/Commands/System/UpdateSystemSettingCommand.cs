using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;

namespace MimirCore.Application.CQRS.BackOffice.Commands.System;

public class UpdateSystemSettingCommand : ICommand
{
    public string Key { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
}

public class UpdateSystemSettingCommandHandler : IRequestHandler<UpdateSystemSettingCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSystemSettingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSystemSettingCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}