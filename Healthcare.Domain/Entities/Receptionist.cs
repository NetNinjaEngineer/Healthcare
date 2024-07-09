using Healthcare.Domain.Enumerations;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;

public class Receptionist : Employee
{
    protected internal Receptionist(string id, string firstName, string lastName, PhoneNumber phone, string jobTitle, decimal salary, DateTime dateOfBirth, DateTime hireDate, Gender gender, string email, Address address) : base(id, firstName, lastName, phone, jobTitle, salary, dateOfBirth, hireDate, gender, email, address)
    {
    }

    private Receptionist() { }
}
