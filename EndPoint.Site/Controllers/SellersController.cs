using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.Commands.RegisterUser;
using eshop.Application.Services.Products.Queries.GetCategories;
using eshop.Application.Services.Sellers.Seller;
using eshop.Common.Dto;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace EndPoint.Site.Controllers
{
    //[Route("[Controller]")]
    public class SellersController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly IRegisterUserService _registerUserService;

        //
        private readonly IMemoryCache _memoryCache;
        public SellersController(ISellerService sellerService, IRegisterUserService registerUserService, IMemoryCache memoryCache)
        {
            _sellerService = sellerService;
            _registerUserService = registerUserService;

            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register(int? catId=null,int? PrcId=null)
        {
            ViewBag.Categories = new SelectList(_sellerService.GetCategories().Data, "CategoryId", "Name", catId);
            //if (ViewBag.SubCategories == null)
            //{
            //    ViewBag.SubCategories = _sellerService.GetSubCategories(null).Data;
            //}
            //if (catId!=null)
            //{
            //    ViewBag.SubCategories = _sellerService.GetSubCategories(catId).Data;
            //}
            //if (catId!=null)
            //{
            //    ViewBag.SubCategories = new SelectList(_sellerService.GetSubCategories(catId).Data, "SubId", "SubName");
            //}
            //ViewBag.Provinces = new SelectList(_sellerService.GetProvinces().Data, "Id", "Name", PrcId);
            //if (PrcId != null)
            //{
            //    ViewBag.Cities = new SelectList(_sellerService.GetCities(PrcId).Data, "Id", "Name");
            //}
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(int Category, string ShopName, string fullname,
                                 string Mobile,
                                 string UserName, string Password, string RePassword)
        {
            RequestRegisterUserDto requestRegisterUser = new RequestRegisterUserDto()
            {
                Email = UserName+"@msn.com",
                FullName = fullname,
                Password = Password,
                ConfirmPassword = RePassword,
                UserName= UserName,
                Role ="Seller"
            };
            var resultRegister = _registerUserService.Execute(requestRegisterUser);
            if (resultRegister.Data.IdentityResult.Succeeded == true)
            {
                RequestAddNewSellerDto request = new RequestAddNewSellerDto()
                {
                    UserName= UserName,
                    CategoryId = Category,
                    Mobile = Mobile,
                    ShopName = ShopName,
                    UserId = resultRegister.Data.UserId,
                };

                return Json(_sellerService.Add(request));
            }
            else
            {
                return Json(resultRegister.Message);
            }
        }
        [HttpPost]
        [Route("GetSubcategories")]
        public IActionResult GetSubcategories(int? catId)
        {
            //ViewBag.SubCategories = new SelectList(_sellerService.GetSubCategories(catId).Data, "SubId", "SubName");
            ViewBag.SubCategories = _sellerService.GetSubCategories(catId).Data;
            return RedirectToAction("Register");
        }

        public IActionResult Categories()
        {
            return View(_sellerService.GetCategories().Data);
        }
        [Route("Sellers")]
        public IActionResult GetSellers( int? categoryId = null)
        {
            return View(_sellerService.GetSellersCategories( categoryId).Data);
        }

        //[HttpGet]
        [HttpGet("{username}")]
        public IActionResult GetsellerProducts(string username)
        {
            //Memorycache 
            var cacheKey = username.ToLower();
            if (!_memoryCache.TryGetValue(cacheKey, out List<SellerProductDto> ProductList))
            {
                ProductList = _sellerService.GetSellerProducts(username).Data;
                var cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(5),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(4),
                    Size = 1024,
                };
                _memoryCache.Set(cacheKey, ProductList, cacheExpirationOptions);
            }
            return View(ProductList);


        }
    }
}
