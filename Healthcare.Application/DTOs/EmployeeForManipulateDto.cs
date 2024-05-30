using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs;
public abstract class EmployeeForManipulateDto
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? JobTitle { get; private set; }
    public string? Phone { get; private set; }
    public DateTime? HireDate { get; private set; }
    public DateTime? DateOfBirth { get; private set; }
    public decimal Salary { get; private set; }
    public Gender Gender { get; private set; }
    public string? Email { get; private set; }
}
