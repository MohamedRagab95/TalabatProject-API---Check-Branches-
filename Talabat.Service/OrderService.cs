using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Services;

namespace Talabat.Service
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, string basketId, DeliveryMethod deliveryMethod, ShippingAddress shippingAddress)
        {
            throw new NotImplementedException();
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
