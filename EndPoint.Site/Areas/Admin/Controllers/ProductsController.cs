using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Operator,Admin")]

    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int Page=1,int Pagesize=20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page,Pagesize).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data,"Id","Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request,List<AddNewProduct_Features> feature)
        {
            List<IFormFile> Lst_images = new List<IFormFile>();
            for(int i=0;i< Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Lst_images.Add(file);
            }
            request.Images = Lst_images;
            request.Features = feature;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }

        public IActionResult Detail(int ProductId)
        {
            return View(_productFacad.GetProductDetailForAdminService.Execute(ProductId).Data);
        }
    }
}
