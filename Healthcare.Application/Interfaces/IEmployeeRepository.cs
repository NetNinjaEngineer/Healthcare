using Healthcare.Domain.Entities;

namespace Healthcare.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<Employee>> GetEmployeesAsync();
    Task SaveChangesAsync();
}
