using eshop.Application.Interfaces.Contexts;
using eshop.Common;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eshop.Application.Services.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDistributedCache _distributedCache;

        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context, IDistributedCache distributedCache)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            int rowcount = 0;
            string cacheKey ="allusers";
            if(request.Str_SearchKey !=null)
            {
                cacheKey = request.Str_SearchKey.ToLower();
            }
            
            List<GetUserDto> Lst_users;
            string serializedUsers;
            var Redis_encodedUsers = _distributedCache.Get(cacheKey);
            if (Redis_encodedUsers != null)
            {
                serializedUsers = Encoding.UTF8.GetString(Redis_encodedUsers);
                Lst_users = JsonConvert.DeserializeObject<List<GetUserDto>>(serializedUsers);
            }
            else
            {

                var users = _context.Users.Select(u => new { u.Id, u.FullName, u.Email, u.IsActive }).AsQueryable();
                if (!string.IsNullOrWhiteSpace(request.Str_SearchKey))
                {
                    users = users.Where(u => u.FullName.Contains(request.Str_SearchKey) || u.Email.Contains(request.Str_SearchKey));
                }
                var userslist = users.ToPaged(request.PageIndex, 20, out rowcount).Select(u => new GetUserDto
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    IsActive = u.IsActive
                }).ToList();

                //cache
                Lst_users = userslist;
                serializedUsers = JsonConvert.SerializeObject(Lst_users);
                Redis_encodedUsers = Encoding.UTF8.GetBytes(serializedUsers);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(16));
                _distributedCache.Set(cacheKey, Redis_encodedUsers, options);
            }
            return new ResultGetUserDto
            {
                Rows = rowcount,
                Users = Lst_users
            };
        }
    }
    
}
