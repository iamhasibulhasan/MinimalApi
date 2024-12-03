using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities.Students;

public sealed class Grade : BaseEntity
{
    public string GradeCode { get; private set; }
    public int EnrollmentId { get; private set; }
    public string GradeValue { get; private set; }

    public Enrollment Enrollment { get; private set; }

}
