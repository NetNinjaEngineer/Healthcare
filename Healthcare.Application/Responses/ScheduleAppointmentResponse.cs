namespace Healthcare.Application.Responses;
public sealed class ScheduleAppointmentResponse
{
    public string? AppointmentId { get; set; } = string.Empty;
    public string? PatientId { get; set; } = string.Empty;
    public string? Department { get; set; } = string.Empty;
    public string? Doctor { get; set; } = string.Empty;
    public DateTime DateOfAppointment { get; set; }
    public DateTime TimeOfAppointment { get; set; }
}
