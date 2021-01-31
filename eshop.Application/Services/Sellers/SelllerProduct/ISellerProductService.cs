using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Domain.Entities.Sellers;

namespace eshop.Application.Services.Sellers.SelllerProduct
{
    public interface ISellerProductService
    {
        ResultDto Add(RequestAddSellerProductDto request);
        ResultDto Edit(RequestEditSellerProductDto request);
        ResultDto Delete(int SellerProductId);
        ResultDto<List<SellerProductDto>> GetSellerProduct(int? SellerId, int? CategoryId);
        ResultDto<List<SubcatDto>> GetSubCategories(int? CategoryId);
        ResultDto<List<ProductDto>> GetProduct(int? CategoryId);

    }
    public class SellerProductService : ISellerProductService
    {
        private readonly IDataBaseContext _context;
        public SellerProductService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Add(RequestAddSellerProductDto request)
        {
            #region Validate Enteries
            if (request.CatId==0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "!دسته بندی را انتخاب نمایید",
                };
            }
          
            if (request.ProductId == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "!محصول را انتخاب نمایید",
                };
            }
             if (request.Inventory == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "!تعداد موجودی را وارد نمایید",
                };
            }
            if (request.SellerPrice == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "!قیمت محصول را نمایید",
                };
            }
            #endregion

            SellerProduct _selllerproduct = new SellerProduct()
            {
                Inventory = request.Inventory,
                ProductId = request.ProductId,
                SellerId = _context.Sellers.SingleOrDefault(s => s.UserId == request.SellerId.ToString() && s.CategoryId==request.CatId).Id,
                SellerPrice = request.SellerPrice,
            };
            _context.SellerProducts.Add(_selllerproduct);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message="کالا با موفقیت  به لیست فروشگاه شمااضافه شد",
            };
                
        }

        public ResultDto Edit(RequestEditSellerProductDto request)
        {
            SellerProduct Sp = _context.SellerProducts.SingleOrDefault(s => s.Id == request.Id);
            Sp.Inventory = request.Inventory;
            Sp.SellerPrice = request.SellerPrice;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عمیات ویرایش با موفقیت انجام شد",
            };
        }

        public ResultDto<List<SubcatDto>> GetSubCategories(int? CategoryId)
        {
            var _subCategories = _context.Categories
                .Where(p => p.ParentCategoryId == CategoryId)
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

        public ResultDto<List<SellerProductDto>> GetSellerProduct(int? sellerId, int? CategoryId)
        {
            var SellerId = _context.Sellers.SingleOrDefault(s => s.UserId ==sellerId.ToString() && s.CategoryId == CategoryId).Id;
            var _products = _context.SellerProducts
                .Where(sp => sp.SellerId == SellerId)
                .Include(sp => sp.Product)
                .ThenInclude(sp => sp.ProductImages).ToList()
                .Select(sp => new SellerProductDto()
                {
                    Id=sp.Id,
                    ProductId = sp.ProductId,
                    ProductImage = sp.Product.ProductImages.FirstOrDefault().Src,
                    ProductName = sp.Product.Name,
                    SellerPrice = sp.SellerPrice,
                    Inventory=sp.Inventory,
                    IsExist = sp.Inventory > 0 ? true : false,
                }).ToList();
            return new ResultDto<List<SellerProductDto>>()
            {
                Data = _products,
                IsSuccess = true,
            };
        }

        public ResultDto<List<ProductDto>> GetProduct(int? CategoryId)
        {
            var _product = _context.Products
                .Where(p => p.CategoryId == CategoryId)
                .ToList()
                .Select(p => new ProductDto()
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                }).ToList();

            return new ResultDto<List<ProductDto>>()
            {
                Data = _product,
                IsSuccess = true,
            };
        }

        public ResultDto Delete(int SellerProductId)
        {
            var sp = _context.SellerProducts.SingleOrDefault(s => s.Id == SellerProductId);
            sp.IsDeleted = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "!محصول با موفقیت حذف گردید",
            };
        }
    }
    public class RequestAddSellerProductDto
    {
        public int CatId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int SellerPrice { get; set; }
        public int Inventory { get; set; }

    }
    public class SellerProductDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int SellerPrice { get; set; }
        public int Inventory { get; set; }
        public bool IsExist { get; set; }

    }
    public class RequestEditSellerProductDto
    {
        public int Id { get; set; }
        public int SellerPrice { get; set; }
        public int Inventory { get; set; }

    }
    public class SubcatDto
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
    }
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

   

}
