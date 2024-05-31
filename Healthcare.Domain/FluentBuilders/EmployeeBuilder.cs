using Healthcare.Domain.Entities;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.FluentBuilders;
public sealed class EmployeeBuilder
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _phone;
    private string? _jobTitle;
    private decimal _salary;
    private DateTime? _birthDate;
    private DateTime? _hireDate;
    private Gender _gender;
    private readonly AddressBuilder _addressBuilder = AddressBuilder.Empty();

    private EmployeeBuilder() { }

    public static EmployeeBuilder Empty() => new();

    public EmployeeBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public EmployeeBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public EmployeeBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public EmployeeBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public EmployeeBuilder WithJobTitle(string jobTitle)
    {
        _jobTitle = jobTitle;
        return this;
    }

    public EmployeeBuilder WithSalary(decimal salary)
    {
        _salary = salary;
        return this;
    }

    public EmployeeBuilder WithBirthDate(DateTime birthDate)
    {
        _birthDate = birthDate;
        return this;
    }

    public EmployeeBuilder WithHireDate(DateTime hireDate)
    {
        _hireDate = hireDate;
        return this;
    }

    public EmployeeBuilder WithGender(Gender gender)
    {
        _gender = gender;
        return this;
    }

    public EmployeeBuilder WithAddress(Action<AddressBuilder> action)
    {
        action(_addressBuilder);
        return this;
    }

    public Employee Build()
    {
        return new Employee
        {
            FirstName = _firstName,
            LastName = _lastName,
            DateOfBirth = _birthDate!.Value,
            HireDate = _hireDate!.Value,
            Gender = _gender,
            Email = _email,
            JobTitle = _jobTitle,
            Phone = _phone,
            Salary = _salary,
            Address = _addressBuilder.Build()
        };
    }

}
