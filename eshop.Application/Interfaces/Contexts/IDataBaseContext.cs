
using eshop.Domain.Entities.Carts;
using eshop.Domain.Entities.City;
using eshop.Domain.Entities.HomePages;
using eshop.Domain.Entities.Orders;
using eshop.Domain.Entities.Payments;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.Sellers;
using eshop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eshop.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
        //DbSet<UserRole> UserRoles { get; set; }
        DbSet<Category> Categories { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<ProductFeatures> ProductFeatures { get; set; }
         DbSet<ProductImages> ProductImages { get; set; }
         DbSet<Slider> Sliders { get; set; }
         DbSet<HomePageImages> HomePageImages { get; set; }
         DbSet<Cart> Carts { get; set; }
         DbSet<CartItem> CartItems { get; set; }
         DbSet<Payment> Payments { get; set; }
         DbSet<Order> Orders { get; set; }
         DbSet<OrderDetail> OrderDetails { get; set; }
         DbSet<SCategory> SCategories { get; set; }
         DbSet<Seller> Sellers { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Province> Provinces { get; set; }
        DbSet<CategoryImage> CategoryImages { get; set; }
        DbSet<SellerProduct> SellerProducts { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());


    }
}
