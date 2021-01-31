using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Linq;

namespace eshop.Application.Services.Commands.DeleteUser
{
    public class DeleteUserService: IDeleteUserService
    {
        private readonly IDataBaseContext _context;

        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }

       public ResultDto Execute(string UserId)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == UserId);
            if(user==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                };
            }

            user.IsDeleted = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر حذف گردید"
            };
        }
    }
}
