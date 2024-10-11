using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;

namespace Talabat.APIS.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorsController : ControllerBase
    {

        public ActionResult Errors (int code)
        {
            if (code == 404)
            {
                return NotFound(new ApiResponseError(404));
            }

            if (code ==401)
            {
                return Unauthorized(new ApiResponseError(401));

            }

            else
                return StatusCode(code);


        }




    }
}
