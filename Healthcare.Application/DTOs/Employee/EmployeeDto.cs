using Healthcare.Application.DTOs.Appointment;
using Healthcare.Application.DTOs.Common;
using Healthcare.Application.DTOs.Department;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Application.DTOs.Employee;
public class EmployeeDto : BaseEntityDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? JobTitle { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
    public string? DepartmentId { get; set; }
    public DepartmentDto? Department { get; set; }
    public ICollection<AppointmentDto> Appointments { get; set; } = [];
}
