namespace Healthcare.Domain.Entities;
public class Nurse : Employee
{
    public required string MedicalDepartmentId { get; set; }
    public MedicalDepartment MedicalDepartment { get; set; } = null!;
}