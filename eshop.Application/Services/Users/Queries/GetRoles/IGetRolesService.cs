using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
