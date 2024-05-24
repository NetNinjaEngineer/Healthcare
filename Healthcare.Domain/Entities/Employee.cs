namespace Healthcare.Domain.Entities;
public class Employee : BaseEntity
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly HireDate { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public string? Phone { get; set; }
}
