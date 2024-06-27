using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class PatientRepository(ApplicationDbContext context)
    : GenericRepository<Patient>(context), IPatientRepository
{
}
