using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Common;
using eshop.Application.Services.Products.Queries.GetProductForAdmin;

namespace eshop.Infrastructure.Services.Products.Queries
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
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
}
