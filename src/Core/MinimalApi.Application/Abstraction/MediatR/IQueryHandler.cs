using MediatR;
using MinimalApi.Application.Common.Utilities;

namespace MinimalApi.Application.Abstraction.MediatR;

public interface IQueryResultHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQueryResult<TResponse>
{
}


public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
