using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Command.Dto;

namespace MinimalApi.Application.ServiceInterfaces.Students;

public interface IStudentService
{
    Task<Result> CreateStudent(CreateStudentDto model, CancellationToken cancellationToken, bool savechanges = true);
}
