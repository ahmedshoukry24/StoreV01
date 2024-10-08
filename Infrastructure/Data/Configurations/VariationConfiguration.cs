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
            builder.Property<string>(s=>s.Serial).HasMaxLength(15);
            builder.Property<string>(c=>c.Color).HasMaxLength(15);
            builder.Property(s=>s.Size).HasMaxLength(15);
            builder.Property(h=>h.Height).HasMaxLength(15);
            builder.Property(w=>w.Width).HasMaxLength(15);
            builder.Property(w=>w.Weight).HasMaxLength(15);
            builder.Property(d=>d.Description).HasMaxLength(300);
            builder.Property(m=>m.Memory).HasMaxLength(15);
            builder.Property(m=>m.RAM).HasMaxLength(15);
            builder.Property(m=>m.CPU).HasMaxLength(15);
            builder.Property(m=>m.Style).HasMaxLength(50);
            builder.Property(m=>m.Model).HasMaxLength(100);
            builder.Property(m=>m.SpecialFeatures).HasMaxLength(200);
            builder.Property(m=>m.GraphicsDescription).HasMaxLength(50);
            builder.HasIndex(x=>x.Serial).IsUnique();
        }
    }
}
