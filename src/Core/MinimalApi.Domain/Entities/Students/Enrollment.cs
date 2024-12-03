using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities.Students;

public sealed class Enrollment : BaseEntity
{
    public string EnrollmentCode { get; private set; }
    public int StudentId { get; private set; }
    public int CourseId { get; private set; }
    public DateTime EnrollmentDate { get; private set; }

    public Student Student { get; private set; }
    public Course Course { get; private set; }
}
