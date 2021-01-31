using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Application.Services.Authentication
{
    public class AccountInfoDto
    {
        public string Id { get; set; }
        [Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "شماره همراه")]
        public string PhoneNumber { get; set; }
        [Display(Name = "تایید ایمیل")]
        public bool EmailConfirmed { get; set; }
        [Display(Name = "تایید موبایل")]
        public bool PhoneNumberConfirmed { get; set; }
        [Display(Name = "ورود دو مرحله ای")]
        public bool TwoFactorEnabled { get; set; }

    }
}
