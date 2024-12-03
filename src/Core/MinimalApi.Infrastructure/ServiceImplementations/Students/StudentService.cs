using MinimalApi.Application.Common.Utilities;
using MinimalApi.Application.Features.Students.Command.Dto;
using MinimalApi.Application.RepositoryInterfaces.Students;
using MinimalApi.Application.ServiceInterfaces.Students;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.ServiceImplementations.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result> CreateStudent(CreateStudentDto model, CancellationToken cancellationToken, bool savechanges = true)
        {
            Student student = Student.Create(model.StudentCode, model.FirstName, model.LastName, model.DateOfBirth, model.Email, model.Phone);
            await _studentRepository.CreateAsync(student, savechanges, cancellationToken);

            return Utility.GetSuccessMsg(CommonMessages.SavedSuccessfully);

        }
    }
}
