using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Repository.Data;

namespace Talabat.Core.Specs.Contract.Products.Specifications
{
    public class ProductWithBrandAndCategorySpecs : BaseSpecification<Product>
    {

        public ProductWithBrandAndCategorySpecs(GetProductsEndPointParams endPointParams)
            :base
            (p=>
                (!endPointParams.BrandId.HasValue || endPointParams.BrandId == p.BrandId)
                &&
                (!endPointParams.CategoryId.HasValue || endPointParams.CategoryId == p.CategoryId)
            )

        {
            Includes.Add(p=>p.Brand);
            Includes.Add(p=>p.Category);

            if(!string.IsNullOrEmpty(endPointParams.Sort))
           {
                
                switch (endPointParams.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

            else
            {
                AddOrderBy(p => p.Name);
            }

            ApplyPagination((endPointParams.PageIndex - 1) * endPointParams.PageSize, endPointParams.PageSize);

        }



        public ProductWithBrandAndCategorySpecs(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

        }

    }
}
