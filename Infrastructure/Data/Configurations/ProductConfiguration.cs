using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(key => key.ID);

            builder.HasMany(x => x.Variations).WithOne(y => y.Product).HasForeignKey(c=>c.ProductId);

            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x=>x.Price).HasColumnType("DECIMAL(18, 2)");

            builder.HasOne(o=>o.Category).WithMany(m=>m.Products).HasForeignKey(c=>c.CategoryId);

            builder.ToTable("Products");
        }
    }
}
