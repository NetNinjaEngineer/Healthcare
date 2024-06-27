namespace Healthcare.Domain.Entities;

public class PrescriptionMedication : BaseEntity
{
    public string PrescriptionId { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;
    public string MedicationId { get; set; } = null!;
    public Medication Medication { get; set; } = null!;
    public string? Dosage { get; set; }
    public string? Instructions { get; set; }
}
