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


            query = specs.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));


            return query;
        }

    }
}
