using Healthcare.Domain.Entities;

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
        Gender Gender)
        : base(FirstName, LastName, JobTitle, Phone, HireDate, DateOfBirth, Salary, Gender)
    {
    }
}
