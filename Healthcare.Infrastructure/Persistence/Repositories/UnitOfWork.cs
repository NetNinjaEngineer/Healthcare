using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IEmployeeRepository EmployeeRepository { get; }
    public IPatientRepository PatientRepository { get; }
    public IAppointmentRepository AppointmentRepository { get; }
    public IDepartmentRepository DepartmentRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        EmployeeRepository ??= new EmployeeRepository(_context);
        PatientRepository ??= new PatientRepository(_context);
        AppointmentRepository ??= new AppointmentRepository(_context);
        DepartmentRepository ??= new DepartmentRepository(_context);
    }

    public async Task CommitAsync() => await _context.SaveChangesAsync();

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        return new GenericRepository<TEntity>(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
