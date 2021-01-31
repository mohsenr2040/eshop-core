using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.AuthenticantionViewModel
{
    public class SignUpViewModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

    }
}
