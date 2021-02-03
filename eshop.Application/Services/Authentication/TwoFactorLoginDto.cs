using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Application.Services.Authentication
{
    //Two factor .........
    public class TwoFactorLoginDto
    {
        [Required]
        public string Code { get; set; }
        public bool IsPersistent { get; set; }
        public string Provider { get; set; }
    }

}
