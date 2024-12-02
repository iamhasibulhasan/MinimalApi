using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
