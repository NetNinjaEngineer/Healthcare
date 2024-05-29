using Healthcare.Domain.Entities;

namespace Healthcare.Application.DTOs;
public abstract record EmployeeForManipulateDto(
    string FirstName,
    string LastName,
    string JobTitle,
    string Phone,
    DateTime HireDate,
    DateTime DateOfBirth,
    decimal Salary,
    Gender Gender)
{
}
