using Healthcare.Domain.Entities;
using System.Linq.Expressions;

namespace Healthcare.Domain.Specifications;
public interface ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; }
}
