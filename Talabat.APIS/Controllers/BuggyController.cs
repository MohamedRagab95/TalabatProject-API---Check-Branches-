using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;
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

            if (product == null)
            {
                return NotFound(new ApiResponseError(404)); 
            
            }

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
            return BadRequest(new ApiResponseError(400));
        }

        [HttpGet("badrequest/{id}")]   //Validation Error
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }

        [HttpGet("unathorized")]   
        public ActionResult GetUnathorizedErroor()
        {
            return Unauthorized(new ApiResponseError(401)) ;
        }


    }
}
