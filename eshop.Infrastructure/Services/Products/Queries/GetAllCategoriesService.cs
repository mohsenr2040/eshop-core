using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Application.Services.Products.Queries.GetAllCategories;

namespace eshop.Infrastructure.Services.Products.Queries
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoryDto>> Execute()
        {
            var _categories = _context.Categories
                .Include(c => c.ParentCategory)
                .Where(c => c.ParentCategoryId != null)
                .ToList()
                .Select(c => new AllCategoryDto
                {
                    Id = c.Id,
                    Name = $"{c.ParentCategory.Name}-{c.Name}",
                }).ToList();

            return new ResultDto<List<AllCategoryDto>>()
            {
                Data = _categories,
                IsSuccess = true,
                Message = "!",
            };

        }
    }
}
