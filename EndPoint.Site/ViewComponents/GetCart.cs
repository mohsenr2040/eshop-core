using EndPoint.Site.Utilities;
using eshop.Application.Services.Carts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class GetCart:ViewComponent
    {
        private ICartService _cartService;
        CookiesManager cookiesManager; 
        public GetCart(ICartService cartService)
        {

            _cartService = cartService;
            cookiesManager = new CookiesManager();
        }
        public IViewComponentResult Invoke()
        {
            var UserId=ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "GetCart", _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), UserId!=null ? UserId: null).Data);
        }
    }

   
}
