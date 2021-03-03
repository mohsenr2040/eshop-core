using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EndPoint.Site.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
      
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        //[Route("Index")]
        public IActionResult Index(Ordering ordering, string SearchKey, int? CatId = null, int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.GetProductForSiteService.Execute(SearchKey, CatId, Page, PageSize, ordering).Data);
        }

        
        [HttpGet("{ProductId}-pka/{ProductName}/{SellerId?}")]
        public IActionResult Detail( int ProductId, int? SellerId=null,string pka="-pka", string ProductName="")
        {
            if (SellerId==null)
            {
                return View(_productFacad.GetProductDetailForSiteService.Execute(ProductId).Data);
            }
            else
            {
                return View(_productFacad.GetProductDetailForSiteService.Execute(ProductId, SellerId).Data);

            }
        }
      
    }
}
