namespace Healthcare.Domain.Entities;

public class LabResult : BaseEntity
{
    public string LabTestId { get; set; } = null!;
    public LabTest LabTest { get; set; } = null!;
    public string AppointmentId { get; set; } = null!;
    public Appointment Appointment { get; set; } = null!;
    public string? Result { get; set; }
    public DateOnly ResultDate { get; set; }
}
