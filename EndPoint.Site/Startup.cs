using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Interfaces.Contexts;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.Carts;
using eshop.Application.Services.Commands.DeleteUser;
using eshop.Application.Services.Commands.EditUser;
using eshop.Application.Services.Commands.RegisterUser;
using eshop.Application.Services.Commands.UserLogin;
using eshop.Application.Services.Commands.UserStatusChange;
using eshop.Application.Services.Common.Queries.GetCategory;
using eshop.Application.Services.Common.Queries.GetMenuItem;
using eshop.Application.Services.Common.Queries.GetMenuItemForMobile;
using eshop.Application.Services.HomePages.AddNewSlider;
using eshop.Application.Services.HomePages.Commands.AddHomePageImages;
using eshop.Application.Services.HomePages.Queries.GetHomePageImages;
using eshop.Application.Services.HomePages.Queries.GetSliders;
using eshop.Application.Services.Orders.Commands.AddNewOrder;
using eshop.Application.Services.Orders.Queries.GetOrdersForAdmin;
using eshop.Application.Services.Orders.Queries.GetUserOrder;
using eshop.Application.Services.Payments.Commands.AddPayment;
using eshop.Application.Services.Payments.Queries.GetPayment;
using eshop.Application.Services.Payments.Queries.GetPaymentForAdmin;
using eshop.Application.Services.Products.FacadPattern;
using eshop.Application.Services.Queries.GetRoles;
using eshop.Application.Services.Queries.GetUsers;
using eshop.Application.Services.Sellers.Seller;
using eshop.Application.Services.Sellers.SelllerPanel;
using eshop.Common.Helpers;
using eshop.Common.Role;
using eshop.Common.Share;
using eshop.Domain.Entities.Users;
using eshop.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(Options =>
            {
                Options.AddPolicy(SeedUserRoles.Admin, policy => policy.RequireRole(SeedUserRoles.Admin));
                Options.AddPolicy(SeedUserRoles.Customer, policy => policy.RequireRole(SeedUserRoles.Customer));
                Options.AddPolicy(SeedUserRoles.Operator, policy => policy.RequireRole(SeedUserRoles.Operator));
            }
            );

            services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Signin");
            });


            services.AddUserServices()
                    .AddDesignServices()
                    .AddBuyingProcessServices()
                    .AddSellerServices();

            //services.AddScoped<IDataBaseContext, DataBaseContext>();
            //services.AddScoped<IGetUsersService, GetUsersService>();
            //services.AddScoped<IGetRolesService, GetRolesService>();
            //services.AddScoped<IRegisterUserService, RegisterUserService>();
            //services.AddScoped<IDeleteUserService, DeleteUserService>();
            //services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
            //services.AddScoped<IEditUserService, EditUserService>();
            //services.AddScoped<IUserLoginService, UserLoginService>();

            //************Facad
            services.AddScoped<IProductFacad, ProductFacad>();

            //**********
            //services.AddScoped<IGetMenuItemService, GetMenuItemService>();
            //services.AddScoped<IGetMenuItemForMobileService, GetMenuItemForMobileService>();
            //services.AddScoped<IGetSearchCategoryService, GetSearchCategoryService>();
            //services.AddScoped<IAddNewSliderService, AddNewSliderService>();
            //services.AddScoped<IGetSliderService, GetSliderService>();
            //services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
            //services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

            //services.AddScoped<ICartService, CartService>();
            //services.AddScoped<IAddPaymentService, AddPaymentService>();
            //services.AddScoped<IAddPaymentService, AddPaymentService>();
            //services.AddScoped<IGetPaymentService, GetPaymentService>();
            //services.AddScoped<IAddNewOrderService, AddNewOrderService>();
            //services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
            //services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
            //services.AddScoped<IGetPaymentForAdminService, GetPaymentForAdminService>();
            //services.AddScoped<ISellerService, SellerService>();
            //services.AddScoped<ISellerPanelService, SellerPanelService>();

            // ------------add service Share
            services.AddScoped<ShareInInstagram>();
            services.AddScoped<ShareInWhatsApp>();
            services.AddScoped<IShareService>(p =>
            {
                string ShareValue = Configuration.GetSection("Share").Value;
                if (ShareValue == "Instagram")
                {
                    return new ShareInInstagram();
                }
                else if (ShareValue == "WhatsApp")
                {
                    return new ShareInWhatsApp();
                }
                return null;
            });
                

            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("eshop-con")));
            services.AddControllersWithViews();


            //----------------add identity------------
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityError>()
                .AddPasswordValidator<PasswordValidator>();

            services.AddAuthorization(option =>
            {
                option.AddPolicy("Buyer", policy =>
                 {
                     policy.RequireClaim("Buyer");
                 });

                option.AddPolicy("AdminUsers", policy =>
                {
                    policy.RequireRole("Admin");
                });
            });
         

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;//!@~#$%^&
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = true;
            }) ;
            services.ConfigureApplicationCookie(option =>
            {
                //cookie setting
                //when user does not work for 10 minutes remined loggin 
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                //option.LoginPath = "Signin";
                option.AccessDeniedPath = new PathString("/AccessDenied");
                //when user does not work for specific time , his account needs to be signed out
                option.SlidingExpiration = true;
            });

            ///Caching
            services.AddMemoryCache();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:4455";
            });

            services.AddDistributedMemoryCache();
            //services.AddDistributedredisCache(option =>
            //{
                
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllerRoute(
                //    name: "Sellers",
                //    pattern: "Sellers",
                //    defaults: new { Controller ="Sellers" ,Action= "Getsellers" ,Type = 1 }
                //    ) ;
                //endpoints.MapControllerRoute(
                //      name: "Sellers",
                //      pattern: "Service-Providers",
                //      defaults: new { Controller = "Sellers", Action = "Getsellers", Type = 2 }
                //      );
                endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //  name: "sellerProducts",
                //  pattern: "{username}",
                //  defaults: new { Controller = "Sellers", Action = "GetsellerProducts" });

             

            });

        }
  }
    
}
