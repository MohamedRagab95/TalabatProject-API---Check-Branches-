using Microsoft.Extensions.Logging.Abstractions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;

namespace Talabat.Repository.Data
{
    class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer multiplexer)
        {
            _database = multiplexer.GetDatabase();
        }



        public async Task<CustomerBasket?> GetBasketAsync(string Id)
        {
            var basket=await  _database.StringGetAsync(Id);

            return basket.IsNullOrEmpty ?null : JsonSerializer.Deserialize<CustomerBasket>(basket);

        }




        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
           var createdOrDeletedBasket =await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));

            if(createdOrDeletedBasket ==false)
                return null;
            else
            return await GetBasketAsync(basket.Id);
        }
       
        public async Task<bool> DeleteBasketAsync(string Id)
        {
          return await  _database.KeyDeleteAsync(Id);
        }
             
    }
}
