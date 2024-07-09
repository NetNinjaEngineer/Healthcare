using Healthcare.Application.DTOs.Common;

namespace Healthcare.Application.DTOs.Appointment;
public class AppointmentDto : BaseDto
{
    public string? EmployeeId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string? PatientId { get; set; }
}
