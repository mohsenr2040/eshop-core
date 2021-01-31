using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(int UserId);
    }
    public class UserStatusChangeService: IUserStatusChangeService
    {
        private readonly IDataBaseContext _context;
        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int UserId)
        {
            var User1 = _context.Users.Find(UserId);
            if(User1==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد !",
                };
            }

            User1.IsActive = !User1.IsActive;
            _context.SaveChanges();

            string Str_userstate = User1.IsActive == true ? "فعال" : "غیرفعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {Str_userstate} شد!"
            };
        }
    }
}
