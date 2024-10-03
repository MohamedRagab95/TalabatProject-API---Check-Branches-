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

        public ProductWithBrandAndCategorySpecs() :base()
        {
            Includes.Add(p=>p.Brand);
            Includes.Add(p=>p.Category);

        }



        public ProductWithBrandAndCategorySpecs(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);

        }

    }
}
