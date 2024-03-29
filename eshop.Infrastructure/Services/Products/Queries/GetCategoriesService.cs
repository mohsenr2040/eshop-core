﻿using eshop.Application.Interfaces.Contexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using eshop.Domain.Entities.Products;
using eshop.Common.Dto;
using eshop.Application.Services.Products.Queries.GetCategories;

namespace eshop.Infrastructure.Services.Products.Queries
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(int? ParentId)
        {
            var _categories = _context.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategoryId == ParentId)
                .ToList()
                .Select(c => new CategoriesDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Parent = c.ParentCategory != null ? new ParentCategoryDto
                    {
                        id = c.ParentCategory.Id,
                        Name = c.ParentCategory.Name
                    }
                    : null,
                    HasChild = c.SubCategories.Count != 0 ? true : false,
                }
                    ).ToList();

            return new ResultDto<List<CategoriesDto>>()
            {
                Data = _categories,
                IsSuccess = true,
                Message = "!لیست باموقیت برگشت داده شد",
            };
        }


    }
}
