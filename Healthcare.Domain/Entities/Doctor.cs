namespace Healthcare.Domain.Entities;
public class Doctor : Employee
{
    public int MedicalDepartmentId { get; set; }
    public MedicalDepartment MedicalDepartment { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = [];
}
