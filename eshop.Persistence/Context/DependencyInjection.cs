using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Context
{
    //add service 
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection  services, IConfiguration  configuration)
        {
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("eshop-con")));
        }
    }
}
