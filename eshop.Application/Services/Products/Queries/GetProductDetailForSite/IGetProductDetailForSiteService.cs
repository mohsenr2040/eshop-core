using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Products.Queries.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForeSiteDto> Execute(int Id);
        ResultDto<ProductDetailForeSiteDto> Execute(int ProductId,int? SellerId);
    }

    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForSiteService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForeSiteDto> Execute(int Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p=>p.ParentCategory)
                .Include(p=>p.SellerProducts)
                .ThenInclude(p=>p.Seller)
                .Include(p => p.ProductImages)
                .Include(p=>p.ProductFeatures)
                .FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                new ResultDto
                {
                    IsSuccess = false,
                    Message = "!محصولی یافت نشد",
                };
            }

            product.ViewCount++;
            _context.SaveChanges();

            if (product.SellerProducts.Where(s=>s.Inventory>0).FirstOrDefault() == null)
            {
                return new ResultDto<ProductDetailForeSiteDto>
                {
                    Data = new ProductDetailForeSiteDto
                    {
                        Id = product.Id,
                        Brand = product.Brand,
                        Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name}",
                        Description = product.Description,
                        Name = product.Name,
                        ImagesSrc = product.ProductImages.Select(p => p.Src).ToList(),
                        Features = product.ProductFeatures.Select(p => new ProductDetailForeSite_FeaturesDto
                        {
                            DisplayName = p.DisplayName,
                            Value = p.Value,
                        }).ToList(),

                    },

                };
            }
            //------add one to number of visited-----
           

            return new ResultDto<ProductDetailForeSiteDto>
            {
                Data = new ProductDetailForeSiteDto
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name}",
                    Description = product.Description,
                    Name = product.Name,
                    SellerId= product.SellerProducts.OrderBy(s => s.SellerPrice).FirstOrDefault().SellerId ,
                    SellerName =product.SellerProducts.OrderBy(s => s.SellerPrice).FirstOrDefault().Seller.ShopName,
                    SellerPrice = product.SellerProducts.OrderBy(s=>s.SellerPrice).FirstOrDefault().SellerPrice,
                    UserName= product.SellerProducts.OrderBy(s => s.SellerPrice).FirstOrDefault().Seller.UserName,
                    ImagesSrc = product.ProductImages.Select(p => p.Src).ToList(),
                    Features = product.ProductFeatures.Select(p => new ProductDetailForeSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),
                    ProdustSellers=product.SellerProducts.Where(sp=>sp.Inventory>0).Select(sp=>new ProdustSellersDto()
                    {
                        SellerId=sp.Seller.Id,
                        SellerName=sp.Seller.ShopName,
                        SellerPrice=sp.SellerPrice,
                        ProductId=sp.ProductId,
                        UserName=sp.Seller.UserName,
                    }).OrderBy(p=>p.SellerPrice).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        
        }

        public ResultDto<ProductDetailForeSiteDto> Execute(int ProductId, int? sellerId)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.SellerProducts)
                .ThenInclude(p => p.Seller)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .FirstOrDefault(p => p.Id == ProductId);


            if (product == null)
            {
                new ResultDto
                {
                    IsSuccess = false,
                    Message = "!محصولی یافت نشد",
                };
            }

            //------add one to number of visited-----
            product.ViewCount++;
            _context.SaveChanges();

            return new ResultDto<ProductDetailForeSiteDto>
            {
                Data = new ProductDetailForeSiteDto
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name}",
                    Description = product.Description,
                    Name = product.Name,
                    SellerId =  sellerId,
                    SellerName = product.SellerProducts.SingleOrDefault(s=>s.SellerId==sellerId).Seller.ShopName,
                    SellerPrice = product.SellerProducts.SingleOrDefault(s => s.SellerId == sellerId).SellerPrice,
                    UserName = product.SellerProducts.SingleOrDefault(s => s.SellerId == sellerId).Seller.UserName,
                    ImagesSrc = product.ProductImages.Select(p => p.Src).ToList(),
                    Features = product.ProductFeatures.Select(p => new ProductDetailForeSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),
                    ProdustSellers = product.SellerProducts.Select(sp => new ProdustSellersDto()
                    {
                        SellerId = sp.Seller.Id,
                        SellerName = sp.Seller.ShopName,
                        SellerPrice = sp.SellerPrice,
                        ProductId=sp.ProductId,
                        UserName=sp.Seller.UserName
                    }).OrderBy(p => p.SellerPrice).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }
    public class ProductDetailForeSiteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int? SellerId { get; set; }
        public string SellerName { get; set; }
        public int SellerPrice { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public List<string> ImagesSrc { get; set; }
        public List<ProductDetailForeSite_FeaturesDto> Features { get; set; }
        public List<ProdustSellersDto> ProdustSellers { get; set; }
    }

    public class ProductDetailForeSite_FeaturesDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
    public class ProdustSellersDto
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public string SellerName { get; set; }
        public int SellerPrice { get; set; }
        public string UserName { get; set; }
    }
}

