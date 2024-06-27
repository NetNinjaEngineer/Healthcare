using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class AppointmentRepository(ApplicationDbContext context)
    : GenericRepository<Appointment>(context), IAppointmentRepository
{
}
