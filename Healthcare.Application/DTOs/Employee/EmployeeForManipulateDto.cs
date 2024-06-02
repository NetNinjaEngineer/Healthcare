using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs.Employee;
public abstract class EmployeeForManipulateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; } = string.Empty;
    public Address Address { get; set; } = default!;
}
