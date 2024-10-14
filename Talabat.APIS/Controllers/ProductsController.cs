using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Specs.Contract.Products.Specifications;

namespace Talabat.APIS.Controllers
{
  
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductCategory> categoryRepo, IGenericRepository<ProductBrand> brandRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductDtO>>> GetProducts(string? sort , int? brandId,int? categoryId)
        {
            var obj= new ProductWithBrandAndCategorySpecs(sort,brandId,categoryId);

           var products=  await _productRepo.GetAllWithSpecsAsync(obj);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDtO>>(products));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDtO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDtO>> GetProduct(int id)
        {
            var obj = new ProductWithBrandAndCategorySpecs(id);

            var product = await _productRepo.GetWithSpecsAsync(obj);
            if (product == null)
                return NotFound(new ApiResponseError(400));

            return Ok(_mapper.Map<Product,ProductDtO>(product));

        }



        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetallCategory()
        {
            var categories = await _categoryRepo.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetallBrands()
        {
            var brands = await _brandRepo.GetAllAsync();

            return Ok(brands);
        }

        #region Static Query
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
        #endregion
    }
}
