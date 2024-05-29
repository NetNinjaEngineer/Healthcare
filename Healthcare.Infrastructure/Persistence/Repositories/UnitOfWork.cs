using Healthcare.Application.Interfaces;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        EmployeeRepository ??= new EmployeeRepository(_context);
    }

    public IEmployeeRepository EmployeeRepository { get; }

    public async Task CommitAsync() => await _context.SaveChangesAsync();
}
