using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync (string buyerEmail,string basketId,DeliveryMethod deliveryMethod,ShippingAddress shippingAddress);

        Task<IReadOnlyList<Order> > GetAllOrdersByBuyerEmailAsync (string buyerEmail);

        Task<Order> GetOrderByOrderIdForBuyerAsync(string buyerEmail, int orderId);

    }
}
