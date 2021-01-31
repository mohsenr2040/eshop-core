using System;

namespace eshop.Application.Services.Queries.GetUsers
{
    public class GetUserDto
    {
        public string UserId { get; set; }
        public String FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
