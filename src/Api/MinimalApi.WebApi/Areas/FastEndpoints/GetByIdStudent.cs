using FastEndpoints;
using MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Queries.GetById;

namespace MinimalApi.WebApi.Areas.FastEndpoints;

public class GetByIdStudent : Endpoint<GetByIdStudentRequest, Result>
{
    private readonly IMediator _mediator;

    public GetByIdStudent(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("api/fastendpoints/student/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetByIdStudentRequest req, CancellationToken cancellationToken)
    {
        Result result;
        var query = new GetByIdStudentQuery(req.id);
        result = await _mediator.Send(query, cancellationToken);
        await SendAsync(result, result.StatusCode);
    }
}
public class GetByIdStudentRequest
{
    [QueryParam]
    public int id { get; init; }
};


