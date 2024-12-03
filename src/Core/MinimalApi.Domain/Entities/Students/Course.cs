using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities.Students;

public sealed class Course : BaseEntity
{
    public string CourseCode { get; private set; }
    public string CourseName { get; private set; }
    public int Credits { get; private set; }
}
