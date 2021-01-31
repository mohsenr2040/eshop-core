using eshop.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Helpers
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        List<string> CommonPassword = new List<string>()
        {
            "123456","123123",""
        };
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            if(CommonPassword.Contains(password))
            {
                var result = IdentityResult.Failed(new IdentityError
                {
                    Code= "CommonPassword",
                    Description= "پسورد شما قابل شناسایی توسط ربات های هکر است! لطفا یک پسورد قوی انتخاب کنید",
                });
                return Task.FromResult(result);
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
