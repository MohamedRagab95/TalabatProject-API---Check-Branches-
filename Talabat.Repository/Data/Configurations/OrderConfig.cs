using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data.Configurations
{
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.Property(o=>o.Status)
                  .HasConversion(s=>s.ToString(),s=>(OrderStatus)Enum.Parse(typeof(OrderStatus),s));

            builder.OwnsOne(o => o.ShippingAddress, o=>o.WithOwner());

            builder.Property(p => p.SubTotal).
                    HasColumnType("decimal(18,2)");



        }
    }
}
