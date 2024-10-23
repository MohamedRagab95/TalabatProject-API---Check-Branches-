using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Repository.Contract;
using Talabat.Core.Services;

namespace Talabat.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<DeliveryMethod> _methodRepo;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrderService(IBasketRepository basketRepository,
                            IGenericRepository<Product> productRepo,
                            IGenericRepository<DeliveryMethod> methodRepo
                           ,IGenericRepository<Order> orderRepo )
        {
           _basketRepository = basketRepository;
            _productRepo = productRepo;
           _methodRepo = methodRepo;
            _orderRepo = orderRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, DeliveryMethod deliveryMethod, ShippingAddress shippingAddress)
        {
            //(string buyerEmail, ShippingAddress shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)

            var basket = await _basketRepository.GetBasketAsync(basketId);

            var OrderItems = new List<OrderItem>();

            if(basket?.Items?.Count > 0)
            {
                foreach(var item in basket.Items)
                {
                    var product = await _productRepo.GetAsync(item.Id);
                    var productItemOrder = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);

                    var orderitem = new OrderItem(productItemOrder,product.Price,item.Quantity);
                    OrderItems.Add(orderitem);
                }
            }


            var subtotal = OrderItems.Sum(i=> i.Price*i.Quantity);  

            var deliverymethod= await _methodRepo.GetAsync(deliveryMethod.Id);


            var order = new Order (buyerEmail,shippingAddress,deliverymethod,OrderItems,subtotal);


            await _orderRepo.AddAsync(order);




            


        }

        public Task<IReadOnlyList<Order>> GetAllOrdersByBuyerEmailAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByOrderIdForBuyerAsync(string buyerEmail, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
