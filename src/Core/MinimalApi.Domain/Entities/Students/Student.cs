using MinimalApi.Domain.Common;

namespace MinimalApi.Domain.Entities.Students;

public sealed class Student : BaseEntity
{
    public string StudentCode { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static Student Create(string studentCode, string firstName, string lastName, DateTime dateOfBirth, string email, string phone)
    {
        Student student = new Student();
        student.StudentCode = studentCode;
        student.FirstName = firstName;
        student.LastName = lastName;
        student.DateOfBirth = dateOfBirth;
        student.Email = email;
        student.Phone = phone;
        return student;
    }

    public void Update(string studentCode, string firstName, string lastName, DateTime dateOfBirth, string email, string phone)
    {
        StudentCode = studentCode;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Phone = phone;
    }
}
