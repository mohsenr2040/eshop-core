using eshop.Application.Services.Carts;
using eshop.Application.Services.Orders.Commands.AddNewOrder;
using eshop.Application.Services.Orders.Queries.GetOrdersForAdmin;
using eshop.Application.Services.Orders.Queries.GetUserOrder;
using eshop.Application.Services.Payments.Commands.AddPayment;
using eshop.Application.Services.Payments.Queries.GetPayment;
using eshop.Application.Services.Payments.Queries.GetPaymentForAdmin;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureBuyingProcessServices
    {
        public static IServiceCollection AddBuyingProcessServices(this IServiceCollection services)
        {
            services.TryAddEnumerable(new ServiceDescriptor[]
                {
                    ServiceDescriptor.Scoped<ICartService, CartService>(),
                    ServiceDescriptor.Scoped<IAddPaymentService, AddPaymentService>(),
                    ServiceDescriptor.Scoped<IAddPaymentService, AddPaymentService>(),// this added twice
                    ServiceDescriptor.Scoped<IGetPaymentService, GetPaymentService>(),
                    ServiceDescriptor.Scoped<IAddNewOrderService, AddNewOrderService>(),
                    ServiceDescriptor.Scoped<IGetUserOrdersService, GetUserOrdersService>(),
                    ServiceDescriptor.Scoped<IGetOrdersForAdminService, GetOrdersForAdminService>(),
                    ServiceDescriptor.Scoped<IGetPaymentForAdminService, GetPaymentForAdminService>(),
                }) ;
            return services;
        }
    }
}
