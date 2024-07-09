using Healthcare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Domain.Specifications;
public static class SpecificationQueryEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(
        IQueryable<T> inputQuery,
        ISpecification<T> specification)
    {
        var query = inputQuery.AsQueryable();

        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        if (specification.Includes is not null)
            query = specification.Includes.Aggregate(query,
                (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

        return query;
    }
}
