using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.APIS.Controllers
{
 
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
           _repository = repository;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket =await _repository.GetBasketAsync(id);

           
             return Ok(basket ?? new CustomerBasket(id)); 

        }


        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket customerBasket)
        {
            var UpdatedOrDeletedBasket =await _repository.UpdateBasketAsync(customerBasket);


            if(UpdatedOrDeletedBasket == null)
            {
                return BadRequest(new ApiResponseError(400));
            }
            return Ok(UpdatedOrDeletedBasket);

        }


        [HttpDelete]

        public async Task DeleteBasket(string id)
        {
          await _repository.DeleteBasketAsync(id);
        }



    }
}
