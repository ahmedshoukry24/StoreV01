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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p=>p.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property<string>(s => s.Serial).HasMaxLength(15);

            builder.HasOne(o => o.ParentCategory).WithMany(m => m.ChildCategories)
                .HasForeignKey(fk => fk.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
