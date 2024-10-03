using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Specs.Contract.Products.Specifications;

namespace Talabat.APIS.Controllers
{
  
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var obj= new ProductWithBrandAndCategorySpecs();

           var products=  await _productRepo.GetAllWithSpecsAsync(obj);

            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var obj = new ProductWithBrandAndCategorySpecs(id);

            var product = await _productRepo.GetWithSpecsAsync(obj);
            if (product == null)
                return NotFound(new {Massage="Not Found" , StatusCode=404});

            return Ok(product);

        }

        //[HttpGet]

        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    var products = await _productRepo.GetAllAsync();

        //    return Ok(products);
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _productRepo.GetAsync(id);
        //    if (product == null)
        //        return NotFound(new { Massage = "Not Found", StatusCode = 404 });

        //    return Ok(product);

        //}
    }
}
