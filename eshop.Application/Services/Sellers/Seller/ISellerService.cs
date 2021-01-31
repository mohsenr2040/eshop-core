using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Sellers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Domain.Entities.Products;

namespace eshop.Application.Services.Sellers.Seller
{
    public interface ISellerService
    {
        ResultDto Add(RequestAddNewSellerDto request);
        ResultDto<List<SellerDto>> GetSellers( int? categoryId);
        ResultDto<List<SellerProductDto>> GetSellerProducts(string UserName);
        ResultDto<List<CategoryDto>> GetCategories();
        ResultDto<List<SubcatDto>> GetSubCategories(int? CategoryId);
        ResultDto<SellersAndCategoriesDto> GetSellersCategories(int? categoryId);
        ResultDto<List<ProvinceDto>> GetProvinces();
        ResultDto<List<CityDto>> GetCities(int? ProvinceId);
        public string GetSellerCategory(string userId);
    }
    public class SellerService : ISellerService
    {
        private readonly IDataBaseContext _context;
        public SellerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Add(RequestAddNewSellerDto request)
        {
            var seller = new eshop.Domain.Entities.Sellers.Seller
            {
                UserName=request.UserName,
                //Addrress = request.Addrress,
                IsActive = true,
                Mobile = request.Mobile,
                //Phone = request.Phone,
                //CityId = request.CityId,
                ShopName = request.ShopName,
                Category=_context.Categories.SingleOrDefault(n=>n.Id==request.CategoryId),
                UserId=request.UserId,
            };
            try
            {
                _context.Sellers.Add(seller);
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "!ثبت نام با موفقیت انجام شد",
                };
            }
            catch(Exception ex)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = ex.ToString(),
                };
            }
          
        }

        public ResultDto<List<CategoryDto>> GetCategories()
        {
            var _categories = _context.Categories
                .Where(c =>  c.ParentCategoryId == null)
                .Include(c => c.CategoryImage)
                .ToList()
                .Select(c => new CategoryDto()
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ImageSrc = c.CategoryImage.FirstOrDefault().Src,
                }).ToList();
            return new ResultDto<List<CategoryDto>>()
            {
                Data = _categories,
                IsSuccess = true,
            };
        }

        public ResultDto<List<CityDto>> GetCities(int? ProvinceId)
        {
            var _cities = _context.Cities
                .Where(c => c.ProvinceId == ProvinceId)
                .Select(c => new CityDto
                {
                    Id = c.CityId,
                    Name = c.CityName
                })
                .ToList();
            return new ResultDto<List<CityDto>>()
            {
                Data = _cities,
                IsSuccess = true,
            };
        }

        public ResultDto<List<ProvinceDto>> GetProvinces()
        {
            var provinces = _context.Provinces
                .Select(p => new ProvinceDto()
                {
                    Id = p.ProvinceId,
                    Name = p.ProvinceName
                }).ToList();
            return new ResultDto<List<ProvinceDto>>()
            {
                Data = provinces,
                IsSuccess = true,
            };
        }

        public ResultDto<List<SellerDto>> GetSellers( int? categoryId)
        {
            var _selles = _context.Sellers
                .Where(s => ( categoryId!=null ? s.CategoryId==categoryId : true))
                 .Include(s => s.Category)
                 //.Include(s => s.City)
                 //.ThenInclude(s => s.Province)
                .ToList()
                .Select(s => new SellerDto()
                {
                    CatName = s.Category.Name,
                    //FullAddrress =  s.City.CityName + "," + s.Addrress,
                    Mobile = s.Mobile,
                    Phone = s.Phone,
                    ShopName = s.ShopName,
                    UserName=s.UserName,
                }).ToList();
            return new ResultDto<List<SellerDto>>()
            {
                Data = _selles,
                IsSuccess = true,
            };
        }

        public ResultDto<List<SellerProductDto>> GetSellerProducts(string UserName)
        {
            var seller = _context.Sellers.SingleOrDefault(s => s.UserName == UserName);
            var _sellerProducts = _context.SellerProducts
                .Where(sp => sp.SellerId == seller.Id)
                .Include(sp=>sp.Seller)
                .Include(sp => sp.Product)
                .ThenInclude(sp => sp.ProductImages)
                .ToList()
                .Select(sp => new SellerProductDto()
                {
                    SellerId=sp.SellerId,
                    ShopName=sp.Seller.ShopName,
                    Inventory = sp.Inventory,
                    ProductId = sp.ProductId,
                    ProductImage = sp.Product.ProductImages.FirstOrDefault().Src,
                    ProductName = sp.Product.Name,
                    SellerPrice = sp.SellerPrice
                }).ToList();

            return new ResultDto<List<SellerProductDto>>()
            {
                Data = _sellerProducts,
                IsSuccess = true,
            };

        }

        public ResultDto<SellersAndCategoriesDto> GetSellersCategories(int? categoryId)
        {
            return new ResultDto<SellersAndCategoriesDto>()
            {
                Data = new SellersAndCategoriesDto()
                {
                    Categories = GetCategories().Data.ToList(),
                    Sellers = GetSellers( categoryId).Data.ToList(),
                },
                IsSuccess=true,
            };
        }

        public ResultDto<List<SubcatDto>> GetSubCategories(int? CategoryId)
        {
            var _subCategories = _context.Categories
                .Where(p => CategoryId!=null ? p.ParentCategoryId== CategoryId : p.ParentCategoryId != null)
                .ToList()
                .Select(p => new SubcatDto()
                {
                    SubName = p.Name,
                    SubId = p.Id
                }).ToList();

            return new ResultDto<List<SubcatDto>>()
            {
                Data = _subCategories,
                IsSuccess = true,
            };
        }

        public string GetSellerCategory(string UserId)
        {
            eshop.Domain.Entities.Sellers.Seller _seller = _context.Sellers.SingleOrDefault(s => s.UserId == UserId);
            string categoryId = _context.Categories.SingleOrDefault(c => c.Id == _seller.CategoryId).Id.ToString();
            return categoryId;
        }
    }

    public class RequestAddNewSellerDto
    {
        public int CategoryId { get; set; }
        public string ShopName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int CityId { get; set; }
        public string Addrress { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
    public class SellersAndCategoriesDto
    {
        public List<SellerDto> Sellers   { get; set; }
        public List<CategoryDto> Categories   { get; set; }
    }
    public class SellerDto
    {
        public int SellerId { get; set; }
        public string CatName { get; set; }
        public string ShopName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string FullAddrress { get; set; }
        public string UserName { get; set; }
    }
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
    }
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProvinceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SellerProductDto
    {
        public int SellerId { get; set; }
        public string ShopName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int SellerPrice { get; set; }
        public int Inventory { get; set; }

    }
    public class SubcatDto
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
    }
}
