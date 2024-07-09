using Healthcare.Domain.Enumerations;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public class Doctor : Employee
{
    protected internal Doctor(string id, string firstName, string lastName, PhoneNumber phone, string jobTitle, decimal salary, DateTime dateOfBirth, DateTime hireDate, Gender gender, string email, Address address) : base(id, firstName, lastName, phone, jobTitle, salary, dateOfBirth, hireDate, gender, email, address)
    {
    }

    private Doctor() { }

    public string? MedicalDepartmentId { get; set; }
    public MedicalDepartment? MedicalDepartment { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<Patient> Patients { get; set; } = [];
}
