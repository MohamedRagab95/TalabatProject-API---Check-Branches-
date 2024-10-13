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

        public ProductWithBrandAndCategorySpecs(string? sort) :base()
        {
            Includes.Add(p=>p.Brand);
            Includes.Add(p=>p.Category);

            if(!string.IsNullOrEmpty(sort))
           {
                
                switch (sort)
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


        }



        public ProductWithBrandAndCategorySpecs(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

        }

    }
}
