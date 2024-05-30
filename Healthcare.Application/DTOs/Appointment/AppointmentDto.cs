using Healthcare.Application.DTOs.Common;
using Healthcare.Application.DTOs.Employee;

namespace Healthcare.Application.DTOs.Appointment;
public class AppointmentDto : BaseEntityDto
{
    public string EmployeeId { get; set; } = string.Empty;
    public EmployeeDto Employee { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string PatientId { get; set; } = string.Empty;

}
