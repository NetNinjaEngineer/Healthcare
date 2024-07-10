using Healthcare.Domain.Entities;
using System.Linq.Expressions;

namespace Healthcare.Domain.Specifications;
public interface ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; }
    public Expression<Func<T, object>>? OrderBy { get; }
    public Expression<Func<T, object>>? OrderByDescending { get; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public bool IsPaginationEnabled { get; set; }
}
