using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class Order :BaseEntity
    {
        public string BuyerName { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ShippingAddress ShippingAddress { get; set; }   // httrgm 1--1 mandatory from both  f el data tt7d f table wa7d elly hoowa order l2n 7atet hna nav.prop

        public DeliveryMethod DeliveryMethod { get; set; }   // 1-m httrmg 1-1 optional -madatory mesh m7tag fk hna

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>;

        public decimal SubTotal { get; set; }
        public decimal GetTotal()=> SubTotal+ DeliveryMethod.Cost;

        public string? PaymentintentId { get; set; }




    }
}
