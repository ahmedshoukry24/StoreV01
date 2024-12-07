using Core.Entities;
using Core.Entities.User;
using Core.Entities.User.UserDetails;
using Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreDbContext : IdentityDbContext<User, Role, Guid, UserClaim, IdentityUserRole<Guid>,  IdentityUserLogin<Guid>, RoleClaim, IdentityUserToken<Guid>>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<User>().HasDiscriminator<string>("Discriminator").HasValue<Customer>("Customer")
            //    .HasValue<Vendor>("Vendor").HasValue<Employee>("Employee");

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            modelBuilder.Entity<Role>().ToTable("Roles");

            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

        }
        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //UserDetails
        //public DbSet<Role> Roles { get;set; }
        //public DbSet<UserClaim> UserClaims { get; set; }
        //public DbSet<RoleClaim> RoleClaims { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartVariation> CartsVariation { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Media> Medias { get; set; }
       
        #endregion

    }
}
