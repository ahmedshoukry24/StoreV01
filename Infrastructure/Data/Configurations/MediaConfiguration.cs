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
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.HasOne(x => x.Store).WithOne(x => x.Media).HasForeignKey<Media>(x => x.StoreId);
            builder.HasOne(x => x.Branch).WithOne(x => x.Media).HasForeignKey<Media>(x => x.BranchId);
            
            
        }
    }
}
