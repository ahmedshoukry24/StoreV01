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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
       public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(400);
            //builder.Property(x => x.Address).HasMaxLength(100);
            builder.Property(x => x.EmailAddress).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property<string>(s=>s.Serial).HasMaxLength(15);
            builder.HasIndex(x=>x.Serial).IsUnique();

            builder.HasMany(x => x.Branches).WithOne(y => y.Store).HasForeignKey(c => c.StoreId);
            //builder.HasOne(x => x.Media).WithOne(x => x.Store).HasForeignKey<Media>(x => x.StoreId);
        }
    }
}
