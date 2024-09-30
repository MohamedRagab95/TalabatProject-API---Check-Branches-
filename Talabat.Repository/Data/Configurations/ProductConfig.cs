using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.PictureUrl).IsRequired();

            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);


        }
    }
}
