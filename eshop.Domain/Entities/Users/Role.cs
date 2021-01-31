using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eshop.Domain.Entities.Users
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
        //public string RoleName { get; set; }
        //public ICollection<UserRole> UserRole { get; set; }
    }
}
