using MediatR;
using MimirCore.Application.CQRS.Common;
using MimirCore.Application.Infrastructure;
using MimirCore.Application.Models.User;

namespace MimirCore.Application.CQRS.Normal.Queries.User;

public class GetUserByEmailQuery : IQuery<UserDto>
{
    public string Email { get; set; }
    
    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserByEmailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}