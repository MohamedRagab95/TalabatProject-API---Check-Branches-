using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.APIS.Controllers
{
 
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository repository,IMapper mapper)
        {
           _repository = repository;
           _mapper = mapper;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket =await _repository.GetBasketAsync(id);

           
             return Ok(basket ?? new CustomerBasket(id)); 

        }


        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto customerBasket)
        {

            var customerbasketmapped= _mapper .Map<CustomerBasketDto,CustomerBasket>(customerBasket);

            var UpdatedOrDeletedBasket =await _repository.UpdateBasketAsync(customerbasketmapped);


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
