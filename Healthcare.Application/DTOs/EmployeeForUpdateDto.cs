﻿using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs;
public sealed record EmployeeForUpdateDto : EmployeeForManipulateDto
{
    public EmployeeForUpdateDto(
        string FirstName,
        string LastName,
        string JobTitle,
        string Phone,
        DateTime HireDate,
        DateTime DateOfBirth,
        decimal Salary,
        Gender Gender,
        string Email)
        : base(FirstName, LastName, JobTitle, Phone, HireDate, DateOfBirth, Salary, Gender, Email)
    {
    }
}
