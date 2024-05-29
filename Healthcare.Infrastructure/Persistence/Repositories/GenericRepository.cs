using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    protected GenericRepository(ApplicationDbContext context) => _context = context;

    public void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public void Delete(TEntity entity) => _context.Remove(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetByIdAsync(int id)
        => await _context.Set<TEntity>().FindAsync(id) ?? default!;

    public void Update(TEntity entity) => _context.Update(entity);
}
