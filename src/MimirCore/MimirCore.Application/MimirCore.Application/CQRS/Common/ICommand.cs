using MediatR;

namespace MimirCore.Application.CQRS.Common;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}