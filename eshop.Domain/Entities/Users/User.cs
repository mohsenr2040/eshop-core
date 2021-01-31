using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Domain.Entities.Users
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage ="نام و نام خانوادگی را وارد نمایید")]
        public String FullName { get; set; }
        //public string Password { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDeleted  { get; set; }
        //public ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
