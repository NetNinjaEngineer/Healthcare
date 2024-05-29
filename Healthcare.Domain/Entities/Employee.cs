using Healthcare.Domain.Events;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public class Employee : BaseEntity
{
    private string _firstName;
    private string _lastName;
    private string _phone;
    private string _jobTitle;
    private decimal _salary;
    private DateTime _dateOfBirth;
    private DateTime _hireDate;
    private Gender _gender;

    public Employee() { }

    public Employee(string firstName, string lastName, string phone,
        string jobTitle, decimal salary, DateTime dateOfBirth, DateTime hireDate,
        Gender gender)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phone = phone;
        _jobTitle = jobTitle;
        _salary = salary;
        _dateOfBirth = dateOfBirth;
        _hireDate = hireDate;
        _gender = gender;

        AddEmployeeCreatedDomainEvent(Id);
    }

    public string FirstName => _firstName;
    public string LastName => _lastName;
    public string Phone => _phone;
    public string JobTitle => _jobTitle;
    public decimal Salary => _salary;
    public DateTime DateOfBirth => _dateOfBirth;
    public DateTime HireDate => _hireDate;
    public Gender Gender => _gender;

    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        _lastName = lastName;
    }

    public void SetPhone(string phone)
    {
        _phone = phone;
    }

    public void SetHiringDate(DateTime hireDate)
    {
        _hireDate = hireDate;
    }

    public void SetGender(Gender gender)
    {
        _gender = gender;
    }

    public void SetJobTitle(string jobTitle)
    {
        _jobTitle = jobTitle;
    }

    public void SetSalary(decimal salary)
    {
        _salary = salary;
    }

    public void SetDateOfBirth(DateTime dateOfBirth)
    {
        _dateOfBirth = dateOfBirth;
    }

    public string GetFirstName() => _firstName;
    public string GetLastName() => _lastName;
    public string GetPhone() => _phone;
    public string GetJobTitle() => _jobTitle;
    public DateTime GetHireDate() => _hireDate;
    public DateTime GetDateOfBirth() => _dateOfBirth;
    public Gender GetGender() => _gender;
    public decimal GetSalary() => _salary;

    public void AddEmployeeCreatedDomainEvent(int employeeId)
    {
        var employeeCreatedDomainEvent = new EmployeeCreatedDomainEvent(employeeId);

        AddDomainEvent(employeeCreatedDomainEvent);
    }
}
