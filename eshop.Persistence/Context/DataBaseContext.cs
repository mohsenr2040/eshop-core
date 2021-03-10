using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using eshop.Domain.Entities.Users;
using eshop.Application.Interfaces.Contexts;
using eshop.Common.Role;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.HomePages;
using eshop.Domain.Entities.Carts;
using eshop.Domain.Entities.Payments;
using eshop.Domain.Entities.Orders;
using eshop.Domain.Entities.Sellers;
using eshop.Domain.Entities.City;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace eshop.Persistence.Context
{
    public class DataBaseContext : IdentityDbContext<User, Role, string>, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SCategory> SCategories { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.RoleId, p.UserId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });

            //modelBuilder.Entity<Order>().HasOne(p => p.User).WithMany(p => p.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>().HasOne(p => p.Payment).WithMany(p => p.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SellerProduct>().HasOne(s => s.Product).WithMany(s => s.SellerProducts).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SellerProduct>().HasOne(s => s.Seller).WithMany(s => s.SellerProducts).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<City>().HasKey(c => c.CityId);
            modelBuilder.Entity<Province>().HasKey(p => p.ProvinceId);

            //modelBuilder.Entity<User>().Ignore(p => p.Id);
            //SeedData(modelBuilder);
            //*********
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Seller>().HasIndex(u => u.UserName).IsUnique();

            //**********
            ApplyQueryFilter(modelBuilder);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>().HasData(new Role { RoleId_pk = 1, RoleName = nameof(SeedUserRoles.Admin) });
            //modelBuilder.Entity<Role>().HasData(new Role { RoleId_pk = 2, RoleName = nameof(SeedUserRoles.Operator) });
            //modelBuilder.Entity<Role>().HasData(new Role { RoleId_pk = 3, RoleName = nameof(SeedUserRoles.Customer) });
            //modelBuilder.Entity<Role>().HasData(new Role { RoleId_pk = 4, RoleName = nameof(SeedUserRoles.Seller) });
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsActive);
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<SellerProduct>().HasQueryFilter(p => p.Inventory > 0);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Slider>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<CartItem>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<Payment>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<SCategory>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<Seller>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<CategoryImage>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<SellerProduct>().HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
