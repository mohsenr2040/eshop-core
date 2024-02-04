using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Domain.Entities.Products;
using eshop.Application.Services.Products.Queries.GetProductDetailForAdmin;

namespace eshop.Infrastructure.Services.Products.Queries
{
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForAdminDto> Execute(int ProductId)
        {
            var _product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == ProductId)
                .FirstOrDefault();
            return new ResultDto<ProductDetailForAdminDto>()
            {
                Data = new ProductDetailForAdminDto()
                {
                    Brand = _product.Brand,
                    Category = GetCategory(_product.Category),
                    Description = _product.Description,
                    Displayed = _product.Displayed,
                    Id = _product.Id,
                    Inventory = _product.Inventory,
                    Name = _product.Name,
                    Price = _product.Price,
                    Features = _product.ProductFeatures.ToList().Select(p =>
                    new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }
                     ).ToList(),
                    Images = _product.ProductImages.ToList().Select(p =>
                      new ProductDetailImagesDto
                      {
                          Id = p.Id,
                          Src = p.Src
                      }).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}
