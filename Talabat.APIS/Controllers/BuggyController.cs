using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Repository.Data;

namespace Talabat.APIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _storeContext.products.Find(100);

            if (product == null) { return NotFound(); }

            return Ok(product);
        
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError() 
        {
            var product = _storeContext.products.Find(100);
            
             var ProductToReturn =product.ToString();

            return Ok(ProductToReturn);
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest() 
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]   //Validation Error
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }


    }
}
