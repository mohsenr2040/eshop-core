using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Application.Services.Authentication
{
    public class VerifyPhoneNumber
    {
        [Required]
        [RegularExpression(@"(\+98|0)?9\d{9}")]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Code { get; set; }
    }
}
