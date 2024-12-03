using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.ServiceInterfaces.Students;

namespace MinimalApi.Application.Features.Students.Command.Update;

public sealed class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
{
    private readonly IStudentService _studentService;

    public UpdateStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.UpdateStudent(request.model, cancellationToken);
    }
}
