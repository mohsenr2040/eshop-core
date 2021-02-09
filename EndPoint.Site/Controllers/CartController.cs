using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Site.Utilities;
using eshop.Application.Services.Carts;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
   //cart controller
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        CookiesManager cookiesManager;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManager = new CookiesManager();
        }
        public IActionResult Index()
        {
            var UserId= ClaimUtility.GetUserId(User);
            var resultGetList=_cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), UserId);
            return View(resultGetList.Data);
        }

        
        public IActionResult AddToCart(int ProductId, int SellerId,string ProductName="")
        {
            var UserId = ClaimUtility.GetUserId(User);
            ViewData["ProductId"] = ProductId;
           var resultAdd=_cartService.AddToCart(ProductId, SellerId, cookiesManager.GetBrowserId(HttpContext),UserId);
           return Redirect("~/products/"+ProductId+"-pka/"+ ProductName.Replace(' ', '-') +"?SellerId="+SellerId);
        }

        public IActionResult Add(int cartItemId)
        {
            _cartService.Add(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(int cartItemId)
        {
            _cartService.LowOff(cartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int ProductId)
        {
            _cartService.RemoveFromCart(ProductId, cookiesManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
