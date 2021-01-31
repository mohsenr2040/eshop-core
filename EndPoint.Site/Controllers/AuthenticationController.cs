using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EndPoint.Site.Models.ViewModels.AuthenticantionViewModel;
using eshop.Application.Services.Authentication;
using eshop.Application.Services.Commands.RegisterUser;
using eshop.Application.Services.Commands.UserLogin;
using eshop.Common.Dto;
using eshop.Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    //[Route("Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;
        private readonly EmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthenticationController(IRegisterUserService registerUserService, IUserLoginService userLoginService,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
            _emailService = new EmailService();
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        [Route("Account")]
        public IActionResult Account()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AccountInfoDto account = new AccountInfoDto()
            {
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FullName = user.FullName ,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName,
            };
            return View(account);
        }


        [HttpGet]
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup(RequestRegisterUserDto request)
        {
            #region validate
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.ConfirmPassword)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }
            #endregion

          
                
            var signupResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                UserName= request.Email,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                Role= "Customer",
            });

            if (signupResult.Data.IdentityResult.Succeeded)
            {
                string CallBackUrl = Url.Action("ConfirmEmail", "Authentication", new
                {
                    UserId = signupResult.Data.UserId,
                    token = signupResult.Data.token
                }, protocol: Request.Scheme);

                string Body = $"لطفا برای فعالسازی کاربری خود بر روی لینک زیر کلیک کنید <br/> <a href={CallBackUrl}>Link</a>";
                _emailService.Execute(request.Email, Body, "فعال سازی نام کاربری");

                //return RedirectToAction("DisplayEmail");

                return Json(new ResultDto()
                {
                    IsSuccess = true,
                    Message = $"!ثبت نام با موفقیت انجام شد<br/>لینک فعالسازی به ایمیل شما ارسال شد"
                });

            }
            //string message = "";
            //foreach (var item in signupResult.Data.IdentityResult.Errors.ToList())
            //{
            //    message += item.Description + Environment.NewLine;
            //}
            //return View( new ResultDto()
            //{
            //    Message = message,
            //});


            if (signupResult.Data.IdentityResult.Succeeded)
            {
                var claims = new List<Claim>()
                {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.FullName),
                new Claim(ClaimTypes.Role, "Customer"),
                };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);
        }

        [Route("Signin")]
        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        [Route("Signin")]
        public IActionResult Signin(USerLoginDto loginDto /*string Email, string Password,bool IsPersistent, string url = "/"*/)
        {
            //USerLoginDto request = new USerLoginDto()
            //{
            //    Username = Email,
            //    Password = Password,
            //    IsPersitent= IsPersistent,
            //    ReturnUrl=url,
            //};
            var signinResult = _userLoginService.Execute(loginDto);
            if(signinResult.Data.SignInResult.RequiresTwoFactor==true)
            {
                return RedirectToAction("TwoFactorLogin", new { loginDto.Username, loginDto.IsPersitent });
            }
            //if (signinResult.IsSuccess == true)
            //{
            //    var claims = new List<Claim>()
            //    {
            //        //new Claim(ClaimTypes.NameIdentifier,signinResult.Data.UserId),
            //        //new Claim(ClaimTypes.Email, Email),
            //        new Claim("FullName", signinResult.Data.FullName,ClaimValueTypes.String),
            //    };
            //    foreach (var item in signinResult.Data.Roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, item));
            //    }
            //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //    var principal = new ClaimsPrincipal(identity);
            //    var properties = new AuthenticationProperties()
            //    {
            //        IsPersistent = IsPersistent,
            //        ExpiresUtc = DateTime.Now.AddDays(5),
            //    };
            //    HttpContext.SignInAsync(principal, properties);

            //}

            return RedirectToAction("index","home");
        }
        [HttpGet]
        [Route("TwoFactorLogin")]
        public IActionResult TwoFactorLogin(string UserName,bool IsPersisent)
        {
            TwoFactorLoginDto twoFactor = new TwoFactorLoginDto();
            var user = _userManager.FindByNameAsync(UserName).Result;
            if(user==null)
            {
                return BadRequest();
            }
            var providers = _userManager.GetValidTwoFactorProvidersAsync(user).Result;
            if(providers.Contains("Phone"))
            {
                string code = _userManager.GenerateTwoFactorTokenAsync(user, "Phone").Result;
                SmsService smsService = new SmsService();
                smsService.Send(user.PhoneNumber, code);

                twoFactor.Provider = "Phone";
                twoFactor.IsPersistent = IsPersisent;
            }
            else if(providers.Contains("Email"))
            {
                string code = _userManager.GenerateTwoFactorTokenAsync(user, "Email").Result;
                EmailService emailService = new EmailService();
                emailService.Execute(user.Email, $"Two Factor Code:{code}", "Two Factor Login");

                twoFactor.Provider = "Email";
                twoFactor.IsPersistent = IsPersisent;
            }
            return View("TwoFactorLogin", twoFactor);
        }
        [HttpPost]
        [Route("TwoFactorLogin")]
        public IActionResult TwoFactorLogin(TwoFactorLoginDto twoFactorLogin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _signInManager.GetTwoFactorAuthenticationUserAsync().Result;
            if(user==null)
            {
                return BadRequest();
            }
            var result = _signInManager.TwoFactorSignInAsync(twoFactorLogin.Provider, twoFactorLogin.Code, twoFactorLogin.IsPersistent, false).Result;
            if(!result.Succeeded)
            {
                ViewBag.Error = "کد وارد  شده صحیح نمی باشد";
            }
            if(result.Succeeded)
            {
                return RedirectToAction("index","home");
            }
            else if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "حساب شما قفل شده است");
                return View();
            }
            return View();
        }

        [Route("Signout")]
        public IActionResult Signout()
        {
            _userLoginService.SignOut();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DisplayEmail()
        {
            return View();
        }
        [Route("ConfirmEmail")]
        [Authorize]
        public IActionResult ConfirmEmail(string UserId,string token)
        {
           var result= _registerUserService.ConfirmEmail(UserId, token).IsSuccess;
            if(result==true)
            {
                return View("~/signin");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            #region validation
            if (Email==null)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "ایمیل خودرا وارد نمایید" });
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }
            #endregion

            var user = _userManager.FindByEmailAsync(Email).Result;
            if(user==null || _userManager.IsEmailConfirmedAsync(user).Result==false)
            {
                return Json(new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربری با این ایمیل ثبت نام نکرده و یا ایمیل تایید نشده است"
                }) ;
            }

            string token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            string CallBackUrl = Url.Action("ResetPassword", "Authentication",
                new { UserId = user.Id, token = token }, protocol: Request.Scheme);

            string Body = $"برای تنظیم مجدد رمز عبور بر روی لینک زیر کلیک کنید <br/> <a href={CallBackUrl}>Link</a>";
            _emailService.Execute(Email, Body, "فراموشی رمز عبور");

            return Json(new ResultDto()
            {
                IsSuccess=true,
                Message="لینک تنظیم مجدد رمز عبور برای شما ارسال شد"
            });
        }

        [HttpGet]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(string UserId,string token)
        {
            return View(new ResetPasswordDto()
            {
                token = token,
                UserId = UserId,
            }
            );
        }
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordDto reset)
        {
            if(!ModelState.IsValid)
            {
                return View(reset);
            }
            if (reset.Password != reset.ConfirmPassword)
            {
                return BadRequest();
            }

            var user = _userManager.FindByIdAsync(reset.UserId).Result;
            if(user ==null)
            {
                return BadRequest();
            }

            var result = _userManager.ResetPasswordAsync(user, reset.token, reset.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }
            else
            {
                ViewBag.Error = result.Errors;
                return View(reset);
            }
        }
        [HttpGet]
        [Route("ResetPasswordConfirmation")]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        [Route("SetPhoneNumber")]
        public IActionResult SetPhoneNumber()
        {
            return View();

        }

        [HttpPost]
        [Route("SetPhoneNumber")]
        [Authorize]
        public IActionResult SetPhoneNumber(SetPhoneNumberDto setPhoneNumber)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var result= _userManager.SetPhoneNumberAsync(user, setPhoneNumber.PhoneNumber).Result;
            string Code = _userManager.GenerateChangePhoneNumberTokenAsync(user, setPhoneNumber.PhoneNumber).Result;
            TempData["PhoneNumber"] = setPhoneNumber.PhoneNumber;
            SmsService smsService = new SmsService();
            smsService.Send(setPhoneNumber.PhoneNumber, Code);
            return RedirectToAction(nameof(VerifyPhoneNumber));
        }

        [HttpGet]
        [Route("VerifyPhoneNumber")]
        [Authorize]
        public IActionResult VerifyPhoneNumber()
        {

            return View(new VerifyPhoneNumber()
            {
                PhoneNumber = "09139738530".ToString(),
            }) ;
        }
        [HttpPost]
        [Route("VerifyPhoneNumber")]
        [Authorize]
        public IActionResult VerifyPhoneNumber(VerifyPhoneNumber verifyPhone)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var result = _userManager.VerifyChangePhoneNumberTokenAsync(user, verifyPhone.Code, verifyPhone.PhoneNumber).Result;
            if(result==false)
            {
                ViewData["message"] = "کد وارد شده اشتباه است";
            }
            else
            {
                
                user.PhoneNumberConfirmed = true;
                _userManager.UpdateAsync(user);
            }
            return View("VerifySuccess");
        }
        [Route("VerifySuccess")]
        [Authorize]
        public IActionResult VerifySuccess()
        {
            return View();
        }
        [Route("TwoFactorEnabled")]
        [Authorize]
        public IActionResult TwoFactorEnabled()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var result = _userManager.SetTwoFactorEnabledAsync(user, !user.TwoFactorEnabled).Result;

            return RedirectToAction("Account");
        }

        [AllowAnonymous]
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// only users with claim buyer can access this action
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy ="Buyer")]
        public string JustBuyer()
        {
            return "You are just buyer!";
        }
    }
}
