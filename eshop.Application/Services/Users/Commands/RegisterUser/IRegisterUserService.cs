using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;


namespace eshop.Application.Services.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
        ResultDto ConfirmEmail(string UserId,string token);
    }

    public class RegisterUserService : IRegisterUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        //private readonly SignInManager<User> _signInManager;
        public RegisterUserService(UserManager<User> userManager, RoleManager<Role> roleManager)
        { 
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ResultDto ConfirmEmail(string UserId, string token)
        {
            if(UserId==null || token==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "",
                };
            }

            var user = _userManager.FindByIdAsync(UserId).Result;
            if(user==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "خطا",
                };
               
            }

            var result = _userManager.ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                user.IsActive = true;
                _userManager.UpdateAsync(user);
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ایمیل شما تایید شد",
                };
            }
            return new ResultDto()
            {
                IsSuccess = false,
                Message = "خطا",
            };
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            //#region Identify Value
            if (String.IsNullOrWhiteSpace(request.FullName))
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId="0",
                        IdentityResult=null,
                    },
                    IsSuccess = false,
                    Message = "!نام را وارد کنید",
                };
            }

            //if (String.IsNullOrWhiteSpace(request.Email))
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "!ایمیل را وارد کنید",
            //    };
            //}

            //string str_emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            //var match = Regex.Match(request.Email, str_emailRegex, RegexOptions.IgnoreCase);

            //if (!match.Success)
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "ایمیل خودرا به درستی وارد نمایید"
            //    };
            //}


            //if (String.IsNullOrWhiteSpace(request.Password))
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "!رمز را وارد کنید",
            //    };
            //}
            //if (String.IsNullOrWhiteSpace(request.RePassword))
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "!تکرار رمز را وارد کنید",
            //    };
            //}
            //if (request.Password != request.RePassword)
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "! رمز و تکرار رمز یکسان نیست",
            //    };
            //}
            //if (request.Roles == null)
            //{
            //    return new ResultDto<ResultRegisterUserDto>()
            //    {
            //        Data = new ResultRegisterUserDto()
            //        {
            //            UserId = 0,
            //        },
            //        IsSuccess = false,
            //        Message = "!نقش را انتخاب کنید",
            //    };
            //}
            //#endregion

            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User User1 = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                UserName=request.UserName,
                IsActive = true,
            };

            var resultUser = _userManager.CreateAsync(User1, request.Password).Result;

          
             var resultRole=  _userManager.AddToRoleAsync(User1,request.Role).Result;
            
            
            Claim newClaim = new Claim("FullName", request.FullName, ClaimValueTypes.String);
            _userManager.AddClaimAsync(User1, newClaim);


            if (resultUser.Succeeded)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        token =_userManager.GenerateEmailConfirmationTokenAsync(User1).Result,
                        IdentityResult = resultUser,
                        UserId = User1.Id,
                    },

                    IsSuccess = true,
                    Message = "!ثبت نام با موفقیت انجام شد",
                };
            }
            else
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        IdentityResult = resultUser,
                        UserId = "0",
                    },

                    IsSuccess = false,
                };
            }
           

        }


    }

    public class RequestRegisterUserDto
    {
        [Required(ErrorMessage = "نام و نام خانوادگی  وارد نمایید")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //[Required]
        public string UserName { get; set; }
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }

    //public class RolesInRegisterUserDto
    //{
    //    public string Role { get; set; }
    //}
    public class ResultRegisterUserDto
    {
        public IdentityResult IdentityResult { get; set; }
        public string UserId { get; set; }
        public string token { get; set; }
    }
}
