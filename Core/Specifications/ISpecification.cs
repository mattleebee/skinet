using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
         Expression<Func<T, bool>> Criteria { get; } // where criteria
         List<Expression<Func<T, object>>> Includes { get; }
         Expression<Func<T, object>> OrderBy { get; }
         Expression<Func<T, object>> OrderByDescending { get; }

         int Skip {get;}
         int Take {get;}
         bool IsPagingEnabled {get;}
         
    }
}