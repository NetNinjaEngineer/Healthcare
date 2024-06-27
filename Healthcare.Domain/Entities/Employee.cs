using Healthcare.Domain.Exceptions;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public abstract class Employee : BaseEntity
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
    public Address? Address { get; set; }

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
}
