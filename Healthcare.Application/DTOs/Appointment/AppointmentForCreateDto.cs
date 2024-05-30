namespace Healthcare.Application.DTOs.Appointment;
public sealed class AppointmentForCreateDto
{
    public string EmployeeId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
}
