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
    public class CartVariationConfiguration : IEntityTypeConfiguration<CartVariation>
    {
        public void Configure(EntityTypeBuilder<CartVariation> builder)
        {
            builder.HasKey(CVkey => new {CVkey.CartId,CVkey.VariationId });

            builder.HasOne(x => x.Cart).WithMany(m => m.CartVariations).HasForeignKey(fk => fk.CartId);

            builder.HasOne(o => o.Variation).WithMany(m => m.CartVariations).HasForeignKey(fk => fk.VariationId);

        }
    }
}
