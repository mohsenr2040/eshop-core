using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Site.Utilities;
using eshop.Application.Services.Sellers.Seller;
using eshop.Application.Services.Sellers.SelllerPanel;
using eshop.Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles ="Seller,Admin")]
    public class PanelController : Controller
    {
        private readonly ISellerPanelService _sellerPanelService;
        private readonly ISellerService _sellerService;
        public PanelController(ISellerPanelService sellerPanelService, ISellerService sellerService )
        {
            _sellerPanelService = sellerPanelService;
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct(int? catId=null,int? subcatId=null)
        {
            string UserId = ClaimUtility.GetUserId(HttpContext.User);
            string _catId = _sellerService.GetSellerCategory(UserId);
            ViewBag.Categories = new SelectList(_sellerService.GetCategories().Data, "CategoryId", "Name", _catId);
          
            ViewBag.SubCategories = new SelectList(_sellerPanelService.GetSubCategories(int.Parse(_catId)).Data, "SubId", "SubName", subcatId);
            
            if (subcatId != null)
            {
                ViewBag.Products = new SelectList(_sellerPanelService.GetProduct(subcatId).Data, "ProductId", "ProductName");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(int CategoryId, int SubcatId, int ProductId,int SellerPrice,int Inventory)
        {
            if(SubcatId==0)
            {
                return Json(new ResultDto()
                {
                    IsSuccess=false,
                    Message="!دسته بندی را انتخاب نمایید",
                });
            }
            string UserId = ClaimUtility.GetUserId(HttpContext.User);

            RequestAddSellerProductDto request = new RequestAddSellerProductDto
            {
                Inventory = Inventory,
                ProductId = ProductId,
                UserId = UserId ,
                SellerPrice = SellerPrice
            };
            return Json(_sellerPanelService.Add(request));
        }
        public IActionResult GetProducts()
        {
            string UserId = ClaimUtility.GetUserId(User);
            return View(_sellerPanelService.GetSellerProduct(UserId).Data);
        }
        public IActionResult Edit(int SpId,int price,int inventory)
        {
            RequestEditSellerProductDto request = new RequestEditSellerProductDto()
            {
                Id = SpId,
                Inventory = inventory,
                SellerPrice = price
            };
            return Json(_sellerPanelService.Edit(request));
        }

        public IActionResult Delete(int SpId)
        {
            return Json(_sellerPanelService.Delete(SpId));
        }

        public IActionResult OrderList(string UserId)
        {
            return View(_sellerPanelService.GetOrders(UserId).Data);
        }
    }
}
