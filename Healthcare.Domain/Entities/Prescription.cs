namespace Healthcare.Domain.Entities;
public class Prescription : BaseEntity
{
    public string AppointmentId { get; set; } = null!;
    public Appointment Appointment { get; set; } = null!;
    public DateOnly PrescriptionDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public ICollection<Medication> Medications { get; set; } = [];
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = [];
}