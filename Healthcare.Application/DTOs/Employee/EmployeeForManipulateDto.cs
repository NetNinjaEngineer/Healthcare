using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs.Employee;
public abstract class EmployeeForManipulateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public string? Phone { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
}
