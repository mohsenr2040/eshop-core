using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
    
}
