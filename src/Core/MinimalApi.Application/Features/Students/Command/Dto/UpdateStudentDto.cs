﻿namespace MinimalApi.Application.Features.Students.Command.Dto;

public sealed class UpdateStudentDto
{
    public int Id { get; set; }
    public string StudentCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
