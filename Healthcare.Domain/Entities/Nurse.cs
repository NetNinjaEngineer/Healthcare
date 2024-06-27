namespace Healthcare.Domain.Entities;
public class Nurse : Employee
{
    public int MedicalDepartmentId { get; set; }
    public MedicalDepartment MedicalDepartment { get; set; } = null!;
}