using eshop.Application.Interfaces.Contexts;
using eshop.Application.Services.Commands.AddNewCategory;
using eshop.Common.Dto;
using eshop.Domain.Entities.Products;
using System;

namespace eshop.Infrastructure.Services.Products.Commands
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int? ParentId, string Name)
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی ",
                };
            }

            var Category1 = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId),
                //ParentCategoryId=ParentId,
            };

            _context.Categories.Add(Category1);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه گردید",
            };
        }

        public Category GetParent(int? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }
    }
}
