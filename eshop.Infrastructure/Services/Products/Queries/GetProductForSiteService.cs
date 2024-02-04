using eshop.Application.Interfaces.Contexts;
using eshop.Common;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using eshop.Domain.Entities.Products;
using Microsoft.Extensions.Caching.Distributed;
//using Newtonsoft.Json;
using eshop.Application.Services.Products.Queries.GetProductForSite;

namespace eshop.Infrastructure.Services.Products.Queries
{
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDataBaseContext _context;

        //cache using
        //private readonly IDistributedCache _distributedCache;
        private readonly IMemoryCache _memoryCache;


        public GetProductForSiteService(IDataBaseContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        //protected IMemoryCache _memoryCache
        //{
        //    get { } set { }
        //}
        public ResultDto<ResultProductForSiteDto> Execute(string SearchKey, int? CatId, int Page, int PageSize, Ordering ordering)
        {
            //Memorycache -------
            var cacheKey = "allproducts";
            //List<Product> List_CachedProducts;
            //string serializedProducts;
            //var Redis_encodedProducts = _distributedCache.Get(cacheKey);
            //if(Redis_encodedProducts!=null)
            //{
            //    serializedProducts = Encoding.UTF8.GetString(Redis_encodedProducts);
            //    List_CachedProducts = JsonConvert.DeserializeObject<List<Product>>(serializedProducts);
            //}
            //else
            if (!_memoryCache.TryGetValue(cacheKey, out List<Product> List_CachedProducts))
            {
                //
                List_CachedProducts = _context.Products
               .Include(p => p.Category)
               .Include(p => p.SellerProducts)
               .Include(p => p.ProductImages).ToList();
                //
                var cacheExpirationOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(5),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(4),
                    Size = 1024,
                };

                _memoryCache.Set(cacheKey, List_CachedProducts, cacheExpirationOption);

                //
                //serializedProducts =
                //JsonConvert.SerializeObject(List_CachedProducts, Formatting.None,
                //        new JsonSerializerSettings()
                //        {
                //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //        });
                //Redis_encodedProducts = Encoding.UTF8.GetBytes(serializedProducts);

                //_distributedCache.Set(cacheKey, Redis_encodedProducts, cacheExpirationOption);

            }

            //_memoryCache
            //if (!_memoryCache.TryGetValue(cacheKey,out List<Product> List_CachedProduct))
            //{
            //    List_CachedProduct = _context.Products
            //    .Include(p => p.SellerProducts)
            //    .Include(p => p.ProductImages).ToList();

            //    var cacheExpirationOption = new MemoryCacheEntryOptions()
            //    {
            //        AbsoluteExpiration = DateTime.Now.AddDays(1),
            //        Priority = CacheItemPriority.Normal,
            //        SlidingExpiration = TimeSpan.FromDays(1),
            //        Size = 10258,
            //    };
            //    _memoryCache.Set(cacheKey, List_CachedProduct,cacheExpirationOption);
            //}


            int TotalRows = 0;
            var productQuery = List_CachedProducts
                .AsQueryable();


            if (CatId != null)
            {
                productQuery = productQuery.Include(p => p.SellerProducts).Where(p => p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
            }
            if (!String.IsNullOrWhiteSpace(SearchKey))
            {
                productQuery = productQuery.Include(p => p.SellerProducts).Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey));
            }

            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostPopular:

                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
            }

            //if (productQuery.ToList().Count == 0)
            //{
            //    productQuery = _context.Products
            //    .Include(p => p.ProductImages).Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey));
            //}
            var products = productQuery.ToPaged(Page, PageSize, out TotalRows);

            //var products2 = _context.Products.FromSqlRaw("SELECT * FROM PRODUCTS").ToList();


            Random rd = new Random();
            return new ResultDto<ResultProductForSiteDto>()
            {
                Data = new ResultProductForSiteDto()
                {
                    Products = products.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        Price = p.SellerProducts.Count > 0 && p.SellerProducts.Count(s => s.Inventory > 0) > 0 ? p.SellerProducts.OrderBy(s => s.SellerPrice).FirstOrDefault().SellerPrice : 0,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                    }).ToList(),
                    TotalRows = TotalRows
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }

}
