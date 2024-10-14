using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specs.Contract.Products.Specifications
{
    public class GetProductsEndPointParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        private const int maxPageSize = 10;

        private int _pagesize;

        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value>maxPageSize ? maxPageSize:value; }
        }

        public int PageIndex { get; set; }

    }
}
