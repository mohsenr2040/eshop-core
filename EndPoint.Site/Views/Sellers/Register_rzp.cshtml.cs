using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.Sellers.Seller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Views.Sellers
{
    public class Register_rzpModel : PageModel
    {
        private readonly ISellerService _sellerService;
        public Register_rzpModel(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public void OnGet(int? catId = null, int? PrcId = null)
        {
            //ViewBag.Categories = new SelectList(_sellerService.GetCategories().Data, "CategoryId", "Name", catId);

        }
    }
}
