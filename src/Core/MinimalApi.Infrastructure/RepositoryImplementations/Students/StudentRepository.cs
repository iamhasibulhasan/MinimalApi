using MinimalApi.Application.RepositoryInterfaces.Students;
using MinimalApi.Domain.Entities.Students;
using MinimalApi.Infrastructure.Persistence;
using MinimalApi.Infrastructure.RepositoryImplementations.Common;

namespace MinimalApi.Infrastructure.RepositoryImplementations.Students
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly RndDbContext _rndDbContext;

        public StudentRepository(RndDbContext rndDbContext) : base(rndDbContext)
        {
            _rndDbContext = rndDbContext;
        }
    }
}
