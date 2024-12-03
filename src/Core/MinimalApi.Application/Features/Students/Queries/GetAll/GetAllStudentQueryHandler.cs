using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.ServiceInterfaces.Students;

namespace MinimalApi.Application.Features.Students.Queries.GetAll;

public sealed class GetAllStudentQueryHandler : IQueryHandler<GetAllStudentQuery, Result>
{
    private readonly IStudentService _studentService;
    public GetAllStudentQueryHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<Result> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
        return await _studentService.GetAllStudent(cancellationToken);
    }
}
