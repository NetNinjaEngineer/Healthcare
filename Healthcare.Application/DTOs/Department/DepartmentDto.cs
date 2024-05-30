using Healthcare.Application.DTOs.Common;
using Healthcare.Application.DTOs.Employee;

namespace Healthcare.Application.DTOs.Department;
public class DepartmentDto : BaseEntityDto
{
    public string? DepartmentName { get; set; }
    public ICollection<EmployeeDto> Employees { get; set; } = [];

}
