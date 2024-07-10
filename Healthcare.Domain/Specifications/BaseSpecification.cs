using Healthcare.Domain.Entities;
using System.Linq.Expressions;

namespace Healthcare.Domain.Specifications;
public abstract class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; } = [];
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public bool IsPaginationEnabled { get; set; }

    protected BaseSpecification() { }
    protected BaseSpecification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        => OrderBy = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByExpression)
        => OrderByDescending = orderByExpression;

    protected void ApplyPagination(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPaginationEnabled = true;
    }

}
