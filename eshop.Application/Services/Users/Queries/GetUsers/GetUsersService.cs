using eshop.Application.Interfaces.Contexts;
using eshop.Common;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Application.Services.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.Select(u => new { u.Id, u.FullName, u.Email,u.IsActive }).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Str_SearchKey))
            {
                users = users.Where(u => u.FullName.Contains(request.Str_SearchKey) || u.Email.Contains(request.Str_SearchKey));
            }
            int rowcount = 0;
            var userslist= users.ToPaged(request.PageIndex, 20, out rowcount).Select(u => new GetUserDto
            {
                UserId = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                IsActive=u.IsActive
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowcount,
                Users = userslist
            };
        }
    }
    
}
