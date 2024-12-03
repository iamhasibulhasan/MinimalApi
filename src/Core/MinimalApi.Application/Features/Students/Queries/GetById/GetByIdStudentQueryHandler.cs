using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.ServiceInterfaces.Students;

namespace MinimalApi.Application.Features.Students.Queries.GetById;

public sealed class GetByIdStudentQueryHandler : IQueryHandler<GetByIdStudentQuery, Result>
{
    private readonly IStudentService _studentService;
    public GetByIdStudentQueryHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<Result> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
    {
        return await _studentService.GetByIdStudent(request.id, cancellationToken);
    }
}
