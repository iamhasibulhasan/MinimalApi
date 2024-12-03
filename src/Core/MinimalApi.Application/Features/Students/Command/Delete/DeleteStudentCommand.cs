using MinimalApi.Application.Abstraction.MediatR;

namespace MinimalApi.Application.Features.Students.Command.Delete
{
    public sealed record DeleteStudentCommand(int id) : ICommand;
}
