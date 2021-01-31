using eshop.Common.Dto;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace eshop.Application.Services.Commands.DeleteUser
{
    public interface IDeleteUserService
    {
        ResultDto Execute(string UserId);
    }
}
