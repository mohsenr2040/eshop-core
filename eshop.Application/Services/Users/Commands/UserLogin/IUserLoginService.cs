using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using eshop.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace eshop.Application.Services.Commands.UserLogin
{
     public interface IUserLoginService
    {
        ResultDto<ResultUserLoginDto> Execute(USerLoginDto request);
       void SignOut();
    }
    public class UserLoginService: IUserLoginService
    {
        
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public UserLoginService(SignInManager<User> signInManager, UserManager<User>  userManager )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public ResultDto<ResultUserLoginDto> Execute(USerLoginDto request)
        {
            if(String.IsNullOrWhiteSpace(request.Username) || String.IsNullOrWhiteSpace(request.Password))
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "!نام کاربری و رمز عبور را وارد نمایید",
                };
            }

            var User1 = _userManager.FindByEmailAsync(request.Username).Result;

            if (User1 == null)
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل در سایت ثبت نام نکرده است",
                };
            }

            _signInManager.SignOutAsync();
            var ResultSingIn=_signInManager.PasswordSignInAsync
                        (User1,request.Password,request.IsPersitent,true).Result;

            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            //bool verified = BCrypt.Net.BCrypt.Verify(request.Password, User1.Password);

            if (!ResultSingIn.Succeeded && ResultSingIn.RequiresTwoFactor == false)
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }

            //List<string> roles = new List<string>();
            //foreach (var item in User1.UserRole)
            //{
            //    roles.Add( item.Role.RoleName);
            //}
            if(ResultSingIn.RequiresTwoFactor==true)
            {
                return new ResultDto<ResultUserLoginDto>()
                {
                    Data = new ResultUserLoginDto()
                    {
                        FullName = User1.FullName,
                        //Roles = roles,
                        UserId = User1.Id,
                        ReturnUrl = request.ReturnUrl,
                        SignInResult = ResultSingIn,
                    }
                };
            }
            if(ResultSingIn.IsLockedOut)
            {

            }
            return new ResultDto<ResultUserLoginDto>()
            {
                Data = new ResultUserLoginDto()
                {
                    FullName = User1.FullName,
                    //Roles = roles,
                    UserId = User1.Id,
                    ReturnUrl=request.ReturnUrl,
                    SignInResult= ResultSingIn,
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };
        }

        public void SignOut()
        {
            _signInManager.SignOutAsync();
        }
    }

    public class ResultUserLoginDto
    {
        public string ReturnUrl { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
        public SignInResult SignInResult { get; set; }
    }

    public class USerLoginDto
    {
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersitent { get; set; } = false;
        public string ReturnUrl { get; set; }
    }
}
