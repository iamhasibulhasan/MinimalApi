using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface IQueryResult<TResponse> : IRequest<Result<TResponse>>
{
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
