using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specs.Contract;

namespace Talabat.Repository.Data
{
    public static class SpecificationEvaluater<T> where T : BaseEntity
    {
        //i can make a dynamic query through this method
        //and be called in generic repository where i can make queris
        public static IQueryable<T> GetQuery(IQueryable<T> dbcontextquery, ISpecification<T> specs)
        {
            var query = dbcontextquery;

            if(specs.Criteria != null) 
            { 
              query = query.Where(specs.Criteria); 
            }


            #region Sorting
            //sort asc
            if (specs.OrderBy != null)
            {
                query = query.OrderBy(specs.OrderBy);

            }

            //sort desc
            else if (specs.OrderByDesc != null)
            {
                query = query.OrderByDescending(specs.OrderByDesc);
            }
            #endregion

            #region EnablePagination

            if (specs.IsAppliedPagination)
                query = query.Skip(specs.Skip).Take(specs.Take); 
            #endregion


            query = specs.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));


            return query;
        }

    }
}
