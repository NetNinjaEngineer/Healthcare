namespace Healthcare.Domain.Entities;

public class Medication : BaseEntity
{
    public string? MedicationName { get; set; }
    public DateOnly ExpireDate { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; } = [];
    public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; } = [];
}