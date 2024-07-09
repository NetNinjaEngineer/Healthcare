namespace Healthcare.Application.DTOs.Appointment;
public sealed class AppointmentForCreateDto
{
    public string? EmployeeId { get; set; }
    public string? PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
}
