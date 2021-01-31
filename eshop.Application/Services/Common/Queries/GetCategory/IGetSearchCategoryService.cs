using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Common.Queries.GetCategory
{
    public interface IGetSearchCategoryService
    {
        ResultDto<List<GetCategoryDto>> Execute();
    }
    public class GetSearchCategoryService : IGetSearchCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetSearchCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetCategoryDto>> Execute()
        {
            var categories = _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToList()
                .Select(c => new GetCategoryDto
                {
                    CategoryName = c.Name,
                    CatId = c.Id
                }).ToList();
            return new ResultDto<List<GetCategoryDto>>()
            {
                Data = categories,
                IsSuccess = true,

            };
        }
    }
    public class GetCategoryDto
    {
        public int CatId { get; set; }
        public string CategoryName { get; set; }
    }
}
