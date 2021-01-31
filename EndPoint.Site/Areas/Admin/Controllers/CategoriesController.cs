using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Operator,Admin")]

    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int? ParentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(ParentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(int? ParentId)
        {
            ViewBag.ParentId = ParentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(int? ParentId,string Name)
        {
            var result=(_productFacad.AddNewCategoryService.Execute(ParentId, Name));
            return Json(result);
        }

    }
}
