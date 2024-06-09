namespace Healthcare.Domain.Entities;
public class EmployeeLog : BaseEntity
{
    public string Action { get; set; } = string.Empty;
    public DateTime ActionTime { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public Employee Employee { get; set; }
}
