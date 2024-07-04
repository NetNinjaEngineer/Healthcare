using Healthcare.Domain.Abstractions;
using Healthcare.Domain.Enumerations;
using Healthcare.Domain.Exceptions;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public class Employee : BaseEntity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public PhoneNumber? Phone { get; private set; }
    public string? JobTitle { get; private set; }
    public decimal Salary { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public DateTime HireDate { get; private set; }
    public Gender Gender { get; private set; }
    public string? Email { get; private set; }
    public Address? AddressInformation { get; private set; }
    public string? ScheduleId { get; private set; }
    public Schedule? Schedule { get; private set; }

    protected Employee()
    {

    }

    internal protected Employee(string? firstName, string? lastName,
        PhoneNumber? phone, string? jobTitle, decimal salary,
        DateTime dateOfBirth, DateTime hireDate, Gender gender,
        string? email, Address? address)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        JobTitle = jobTitle;
        Salary = salary;
        DateOfBirth = dateOfBirth;
        HireDate = hireDate;
        Gender = gender;
        Email = email;
        AddressInformation = address;
    }

    public static Result<Employee> Create(string firstName, string lastName,
        PhoneNumber phoneNumber, string jobTitle, decimal salary,
        DateTime dateOfBirth, DateTime hireDate, Gender gender, string email, Address address)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Result<Employee>.Failure(DomainErrors.Employee.EmptyFirstName);

        if (string.IsNullOrWhiteSpace(lastName))
            return Result<Employee>.Failure(DomainErrors.Employee.EmptyLastName);

        return Result<Employee>.Success(new Employee(firstName, lastName, phoneNumber,
            jobTitle, salary, dateOfBirth, hireDate, gender, email, address));

    }

    public void UpdateContactInformation(string phoneNumber, string emailAddress,
        string street, string city, string state, string postalCode, string country)
    {
        Result<PhoneNumber> phoneResult = PhoneNumber.Create(phoneNumber);

        if (!phoneResult.IsSuccess)
            throw new InvalidOperationException(phoneResult.Error.Description);

        Result<Address> addressResult = Address.Create(street, city, postalCode, state, country);
        if (!addressResult.IsSuccess)
            throw new InvalidOperationException(addressResult.Error.Description);

        Phone = phoneResult.Value;
        AddressInformation = addressResult.Value;
    }



    public int GetEmployeeAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;

        if (DateOfBirth.Date > today.AddYears(-age))
            age--;
        return age;
    }

    public void PromoteEmployee(decimal salaryIncrease)
    {
        if (salaryIncrease < 0)
            throw new SalaryIncreaseException("salary must not be less than 0.");

        Salary += salaryIncrease;

    }
}
