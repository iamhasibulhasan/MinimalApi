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

        public async Task<Result> DeleteStudent(int id, CancellationToken cancellationToken, bool savechanges = true)
        {
            var exists = await _studentRepository.GetByIdAsync(id, cancellationToken);
            if (exists is null)
            {
                return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
            }
            await _studentRepository.DeleteAsync(id, savechanges, cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.DeletedSuccessfully);
        }

        public async Task<Result> UpdateStudent(UpdateStudentDto model, CancellationToken cancellationToken, bool savechanges = true)
        {
            var exists = await _studentRepository.GetByIdAsync(model.Id, cancellationToken);
            if (exists is null)
            {
                return Utility.GetNoDataFoundMsg(CommonMessages.NoDataFound);
            }
            exists.Update(model.StudentCode, model.FirstName, model.LastName, model.DateOfBirth, model.Email, model.Phone);
            await _studentRepository.UpdateAsync(exists, savechanges, cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.UpdatedSuccessfully);
        }

        #region Query

        public async Task<Result> GetAllStudent(CancellationToken cancellationToken)
        {
            var res = await _studentRepository.GetAllAsync(cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
        }

        public async Task<Result> GetByIdStudent(int id, CancellationToken cancellationToken)
        {
            var res = await _studentRepository.GetByIdAsync(id, cancellationToken);
            return Utility.GetSuccessMsg(CommonMessages.DataExists, res);
        }

        #endregion
    }
}
