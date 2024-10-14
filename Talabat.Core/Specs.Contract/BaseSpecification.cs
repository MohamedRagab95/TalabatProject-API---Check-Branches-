using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specs.Contract;

namespace Talabat.Repository.Data
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get ; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get ; set; }
        public Expression<Func<T, object>> OrderByDesc { get ; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IsAppliedPagination { get; set; } = false;

        public BaseSpecification(Expression<Func<T, bool>> _criteria)
        {
            Criteria= _criteria;
        }
        public BaseSpecification()
        {
            
        }

        public void AddOrderBy(Expression<Func<T, object>> _orderBy)
        {
            OrderBy= _orderBy;
        }

        public void AddOrderByDesc(Expression<Func<T, object>> _orderByDesc)
        {
            OrderByDesc = _orderByDesc;
        }

        public void ApplyPagination (int skip ,int take)
        {
            IsAppliedPagination= true;
            Skip= skip;
            Take= take;
        }

    }
}
