using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class DepartmentRepository(ApplicationDbContext context)
    : GenericRepository<Department>(context), IDepartmentRepository
{
}
