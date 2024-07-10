using Healthcare.Domain.Entities;
using Healthcare.Domain.Specifications;

namespace Healthcare.Application.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(string id);
    void Create(TEntity entity);
    void CreateCollection(IEnumerable<TEntity> colllection);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    bool CheckExists(string id);
    Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specification);
    Task<TEntity?> GetByIdWithSpecificationAsync(string id, ISpecification<TEntity> specification);
    Task<int> GetCountWithSpecificationAsync(ISpecification<TEntity> specification);
}
