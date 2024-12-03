using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities.Students;

public sealed class Attendance : BaseEntity
{
    public int EnrollmentId { get; private set; }
    public DateTime Date { get; private set; }
    public int StudentStatus { get; private set; }

    public Enrollment Enrollment { get; private set; }
}
