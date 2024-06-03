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
    public class VariationConfiguration : IEntityTypeConfiguration<Variation>
    {
        public void Configure(EntityTypeBuilder<Variation> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Price).HasColumnType("DECIMAL(18, 2)");
            builder.Property(x => x.SKU).HasMaxLength(100);


        }
    }
}
