using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Common.Queries.GetMenuItemForMobile
{
    public interface IGetMenuItemForMobileService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
    public class GetMenuItemForMobileService : IGetMenuItemForMobileService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemForMobileService(IDataBaseContext context)
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
                    CategoryName = c.Name,
                    Child = c.SubCategories.Select(s => new MenuItemDto
                    {
                        CategoryName = s.Name,
                        CatId = s.Id
                    }).ToList()
                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                Data = _categories,
                IsSuccess = true,
            };
        }
    }

    public class MenuItemDto
    {
        public int CatId { get; set; }
        public string CategoryName { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}
