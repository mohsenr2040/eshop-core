using eshop.Application.Services.Common.Queries.GetCategory;
using eshop.Application.Services.Common.Queries.GetMenuItem;
using eshop.Application.Services.Common.Queries.GetMenuItemForMobile;
using eshop.Application.Services.HomePages.AddNewSlider;
using eshop.Application.Services.HomePages.Commands.AddHomePageImages;
using eshop.Application.Services.HomePages.Queries.GetHomePageImages;
using eshop.Application.Services.HomePages.Queries.GetSliders;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureDesignServices
    {
        public static IServiceCollection AddDesignServices(this IServiceCollection services)
        {
            services.TryAddEnumerable(new ServiceDescriptor[]
                {
                     ServiceDescriptor.Scoped<IGetMenuItemService, GetMenuItemService>(),
                     ServiceDescriptor.Scoped<IGetMenuItemForMobileService, GetMenuItemForMobileService>(),
                     ServiceDescriptor.Scoped<IGetSearchCategoryService, GetSearchCategoryService>(),
                     ServiceDescriptor.Scoped<IAddNewSliderService, AddNewSliderService>(),
                     ServiceDescriptor.Scoped<IGetSliderService, GetSliderService>(),
                     ServiceDescriptor.Scoped<IAddHomePageImagesService, AddHomePageImagesService>(),
                     ServiceDescriptor.Scoped<IGetHomePageImagesService, GetHomePageImagesService>(),
                });
            return services;
        }
    }
}
