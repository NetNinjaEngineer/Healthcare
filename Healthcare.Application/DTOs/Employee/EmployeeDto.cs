using Healthcare.Application.DTOs.Common;
using Healthcare.Domain.Enumerations;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs.Employee;
public class EmployeeDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public PhoneNumber? Phone { get; set; }
    public string? JobTitle { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
    public string? DepartmentId { get; set; }
    public Address? AddressInformation { get; set; }
}
