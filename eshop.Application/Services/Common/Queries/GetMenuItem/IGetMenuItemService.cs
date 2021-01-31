using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<MenuItemDto>> Execute()
        {
            var _categories = _context.Categories
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategoryId == null)
                .ToList()
                .Select(c => new MenuItemDto
                {
                    CatId = c.Id,
                    Child = c.SubCategories.Select(s => new MenuItemDto
                    {
                        CatId = s.Id,
                        Name = s.Name,
                    }).ToList(),
                    Name = c.Name,
                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                IsSuccess = true,
                Data = _categories,
                Message = "",
            };
        }
    }

    public class MenuItemDto
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }

}
