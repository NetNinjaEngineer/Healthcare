using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class EmployeeRepository(ApplicationDbContext context)
    : GenericRepository<Employee>(context), IEmployeeRepository
{
}
