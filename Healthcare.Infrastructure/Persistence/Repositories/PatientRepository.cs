using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }
}
