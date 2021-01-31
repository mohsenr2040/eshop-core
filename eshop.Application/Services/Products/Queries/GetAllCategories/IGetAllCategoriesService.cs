using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoryDto>> Execute();
    }

    public class GetAllCategoriesService: IGetAllCategoriesService
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
                    Name =$"{c.ParentCategory.Name}-{c.Name}" ,
                }).ToList();

            return new ResultDto<List<AllCategoryDto>>()
            {
                Data = _categories,
                IsSuccess = true,
                Message="!",
            };

        }
    }

    public class AllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
