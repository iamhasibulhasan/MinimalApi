using MinimalApi.Application.RepositoryInterfaces.Common;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Application.RepositoryInterfaces.Students
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
    }
}
