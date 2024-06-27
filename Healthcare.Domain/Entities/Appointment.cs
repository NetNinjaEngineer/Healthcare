namespace Healthcare.Domain.Entities;

public class Appointment : BaseEntity
{
    public string? Reason { get; set; }
    public DateOnly DateOfAppointment { get; set; }
    public TimeOnly TimeOfAppointment { get; set; }
    public bool Paid { get; set; }
    public string DoctorId { get; set; } = null!;
    public string PatientId { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}