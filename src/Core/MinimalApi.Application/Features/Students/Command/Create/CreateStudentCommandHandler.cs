using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.ServiceInterfaces.Students;

namespace MinimalApi.Application.Features.Students.Command.Create;

public sealed class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand>
{
    private readonly IStudentService _studentService;
    public CreateStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.CreateStudent(request.model, cancellationToken);
    }
}
