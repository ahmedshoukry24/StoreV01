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
    public class BranchProductConfiguration: IEntityTypeConfiguration<BranchProducts>
    {
        public void Configure(EntityTypeBuilder<BranchProducts> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x=>new {x.ProductId, x.BranchId});
            entityTypeBuilder.Property(x=>x.Price).IsRequired().HasColumnType("DECIMAL(18, 2)");
            entityTypeBuilder.HasOne(x => x.Product).WithMany(x => x.BranchesProducts).HasForeignKey(x=>x.ProductId);
            entityTypeBuilder.HasOne(x => x.Branch).WithMany(x => x.BranchProducts).HasForeignKey(x=>x.BranchId);
        }
    }
}
