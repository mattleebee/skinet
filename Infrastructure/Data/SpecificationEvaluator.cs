using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // add where expression eg product id
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy); // add where expression eg product id
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending); // add where expression eg product id
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            // aggregate include expressions eg product type and brand
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
        
    }
}