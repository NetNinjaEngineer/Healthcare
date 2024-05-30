using Healthcare.Domain.Events;
using Healthcare.Domain.Exceptions;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public class Employee : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? JobTitle { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = [];

    public Employee() { }

    public Employee(string? firstName, string? lastName, string? phone,
        string? jobTitle, decimal salary, DateTime dateOfBirth, DateTime hireDate, Gender gender, string? email)
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
    }

    public string? GetFirstName() => FirstName;
    public string? GetLastName() => LastName;
    public string? GetPhone() => Phone;
    public string? GetJobTitle() => JobTitle;
    public DateTime GetHireDate() => HireDate;
    public DateTime GetDateOfBirth() => DateOfBirth;
    public Gender GetGender() => Gender;
    public decimal GetSalary() => Salary;
    public string? GetEmail() => Email;

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
            throw new SalaryIncreaseException(ErrorMessages.SalaryIncreaseLessThanZero);

        Salary += salaryIncrease;

    }


    public void AddEmployeeCreatedDomainEvent(string employeeId)
    {
        var employeeCreatedDomainEvent = new EmployeeCreatedDomainEvent(employeeId);

        AddDomainEvent(employeeCreatedDomainEvent);
    }

    public void AddEmployeePromotedDomainEvent(decimal salaryIncrease)
    {
        var employeePromotedDomainEvent = new EmployeePromotedDomainEvent(salaryIncrease, this);

        AddDomainEvent(employeePromotedDomainEvent);
    }


}
