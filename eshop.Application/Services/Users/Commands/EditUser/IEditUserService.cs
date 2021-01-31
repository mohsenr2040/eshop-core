using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }

    public class EditUserService: IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditUserDto request)
        {
            var User1 = _context.Users.Find(request.UserId);
            if (User1 == null)
            {
                new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد !"
                };
            }

            User1.FullName = request.FullName;
            User1.Email = request.Email;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عملیات ویرایش انجام شد",
            };
        }
    }

    public class RequestEditUserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
