using Healthcare.Domain.Enumerations;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;

public class Pharmacist : Employee
{
    private Pharmacist() { }

    protected internal Pharmacist(string? firstName, string? lastName, PhoneNumber? phone, string? jobTitle, decimal salary, DateTime dateOfBirth, DateTime hireDate, Gender gender, string? email, Address? address) : base(firstName, lastName, phone, jobTitle, salary, dateOfBirth, hireDate, gender, email, address)
    {
    }
}
