namespace Healthcare.Application.DTOs;
public sealed class AppointmentForCreateDto
{
    public string EmployeeId { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public TimeOnly AppointmentTime { get; set; }
}
