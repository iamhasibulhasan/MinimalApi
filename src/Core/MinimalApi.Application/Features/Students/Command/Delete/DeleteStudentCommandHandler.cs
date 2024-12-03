using MinimalApi.Application.Abstraction.MediatR;
using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.ServiceInterfaces.Students;

namespace MinimalApi.Application.Features.Students.Command.Delete;

public sealed class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand>
{
    private readonly IStudentService _studentService;

    public DeleteStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }
    public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.DeleteStudent(request.id, cancellationToken);
    }
}
