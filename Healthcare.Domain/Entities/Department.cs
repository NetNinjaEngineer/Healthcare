namespace Healthcare.Domain.Entities;
public class Department : BaseEntity
{
    public string DepartmentName { get; set; } = string.Empty;
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
