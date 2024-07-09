using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;
using Healthcare.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Persistence.Repositories;
public class GenericRepository<TEntity>(ApplicationDbContext context)
    : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    public bool CheckExists(string id) => context.Set<TEntity>().Any(x => x.Id == id);

    public void Create(TEntity entity) => context.Set<TEntity>().Add(entity);

    public void CreateCollection(IEnumerable<TEntity> colllection)
        => context.BulkInsert(colllection);

    public void Delete(TEntity entity) => context.Remove(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetByIdAsync(string id)
        => await context.Set<TEntity>().FindAsync(id) ?? default!;

    public void Update(TEntity entity) => context.Update(entity);

    public async Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specification)
        => await SpecificationQueryEvaluator<TEntity>.GetQuery(context.Set<TEntity>(), specification).ToListAsync();
    public async Task<TEntity?> GetByIdWithSpecificationAsync(string id, ISpecification<TEntity> specification)
        => await SpecificationQueryEvaluator<TEntity>.GetQuery(context.Set<TEntity>(), specification).FirstOrDefaultAsync(x => x.Id == id);
}
