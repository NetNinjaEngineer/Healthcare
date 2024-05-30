namespace Healthcare.Application.DTOs;
public sealed class EmployeeForListDto : BaseEntityDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? JobTitle { get; set; }
    public string? Phone { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
}
