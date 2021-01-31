using eshop.Application.Interfaces.Contexts;
using eshop.Application.Services.Commands.DeleteUser;
using eshop.Application.Services.Commands.EditUser;
using eshop.Application.Services.Commands.RegisterUser;
using eshop.Application.Services.Commands.UserLogin;
using eshop.Application.Services.Commands.UserStatusChange;
using eshop.Application.Services.Queries.GetRoles;
using eshop.Application.Services.Queries.GetUsers;
using eshop.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureUserServices
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services )
        {
            services.TryAddEnumerable(new ServiceDescriptor[]
                {
                    ServiceDescriptor.Scoped<IDataBaseContext, DataBaseContext>(),
                    ServiceDescriptor.Scoped<IGetUsersService, GetUsersService>(),
                    ServiceDescriptor.Scoped<IGetRolesService, GetRolesService>(),
                    ServiceDescriptor.Scoped<IRegisterUserService, RegisterUserService>(),
                    ServiceDescriptor.Scoped<IDeleteUserService, DeleteUserService>(),
                    ServiceDescriptor.Scoped<IUserStatusChangeService, UserStatusChangeService>(),
                    ServiceDescriptor.Scoped<IEditUserService, EditUserService>(),
                    ServiceDescriptor.Scoped<IUserLoginService, UserLoginService>(),
                });
            return services;
        }
    }
}
