using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace eshop.Application.Services.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RolesDto>> Execute()
        {
            var Roles = _context.Roles.ToList().Select(r => new RolesDto
            {
                RoleId = r.Id.ToString(),
                RoleName = r.Name
            }).ToList();

            return new ResultDto<List<RolesDto>>()
            {
                Data = Roles,
                IsSuccess = true,
                Message = "",
            };

        }
    }
}
