using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Repository.Data;

namespace Talabat.Core.Specs.Contract.Products.Specifications
{
  public  class GetAllProductsInPagination : BaseSpecification<Product>
    {

        public GetAllProductsInPagination(GetProductsEndPointParams endPointParams) 
            :base (p => 
            (!endPointParams.BrandId.HasValue || endPointParams.BrandId == p.BrandId)
                &&
                (!endPointParams.CategoryId.HasValue || endPointParams.CategoryId == p.CategoryId)
            )
        {
            
        }




    }
}
