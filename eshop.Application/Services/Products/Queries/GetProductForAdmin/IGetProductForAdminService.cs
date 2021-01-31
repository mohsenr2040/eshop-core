using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Common;

namespace eshop.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int Page=1,int PageSize=20);
    }
    public class GetProductForAdminService: IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductForAdminDto> Execute(int Page=1,int PageSize=20)
        {
            int rowcount = 0;
            var _products = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowcount)
                .Select(p => new ProductsFormAdminList_Dto()
                {
                    ProductId = p.Id,
                    Brand = p.Brand,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    Products = _products,
                    CurrentPage = Page,
                    RowCount = rowcount,
                    PageSize = PageSize,
                },
                IsSuccess = true,
                Message = "",
            };
        }

    }
    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductsFormAdminList_Dto> Products { get; set; }
    }
    public class ProductsFormAdminList_Dto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
