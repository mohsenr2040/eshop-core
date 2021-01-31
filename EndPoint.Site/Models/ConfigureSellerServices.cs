using eshop.Application.Services.Sellers.Seller;
using eshop.Application.Services.Sellers.SelllerPanel;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureSellerServices
    {
        public static IServiceCollection AddSellerServices(this IServiceCollection services)
        {
            services.TryAddEnumerable(new ServiceDescriptor[]
                {
                    ServiceDescriptor.Scoped<ISellerService, SellerService>(),
                    ServiceDescriptor.Scoped<ISellerPanelService, SellerPanelService>(),
                }) ;
            return services;
        }
    }
}
