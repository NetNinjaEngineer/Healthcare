namespace Healthcare.Domain.Entities;
public class Doctor : Employee
{
    public required string MedicalDepartmentId { get; set; }
    public MedicalDepartment MedicalDepartment { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<Patient> Patients { get; set; } = [];
}
