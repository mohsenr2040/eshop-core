using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.Seller_Service.Categories
{
    public interface ISCategoriesService
    {
        ResultDto Execute(int? ParentId,string name);
    }
    public class SCategoriesService : ISCategoriesService
    {
        private readonly IDataBaseContext _context;
        public SCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int? ParentId, string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام را وارد کنید",
                };
            }

            SCategory sCategory = new SCategory
            {
                Name = name,
                ParentCategory =_context.SCategories.Find( ParentId),
            };
            _context.SCategories.Add(sCategory);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه گردید",
            };
        }
    }
}
