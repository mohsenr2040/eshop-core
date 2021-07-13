using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Site.Utilities;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.MongoDb;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EndPoint.Site.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly CommentService _commentService;
      
        public ProductsController(IProductFacad productFacad, CommentService commentService)
        {
            _productFacad = productFacad;
            _commentService = commentService;
        }
        //[Route("Index")]
        public IActionResult Index(Ordering ordering, string SearchKey, int? CatId = null, int Page = 1, int PageSize = 20)
        {
            return View(_productFacad.GetProductForSiteService.Execute(SearchKey, CatId, Page, PageSize, ordering).Data);
        }


        [HttpGet("{ProductId}-pka/{ProductName}/{SellerId?}")]
        public IActionResult Detail( int ProductId, int? SellerId=null,string pka="-pka", string ProductName="")
        {
            try
            {
                ViewBag.Comments = _commentService.Get(ProductId.ToString()).Data;
            }
            catch { }

            if (SellerId==null)
            {
                return View(_productFacad.GetProductDetailForSiteService.Execute(ProductId).Data);
            }
            else
            {
                return View(_productFacad.GetProductDetailForSiteService.Execute(ProductId, SellerId).Data);

            }
        }

        [HttpPost]
        [Route("Products/RegisterComment")]
        public IActionResult RegisterComment(string Text,string ProductId)
        {
            string UserId = ClaimUtility.GetUserId(HttpContext.User);
            string UserFullName = ClaimUtility.GetUserFullName(HttpContext.User);

            return Json(_commentService.Create(ProductId, Text, UserId, UserFullName));
        }

        [HttpPost]
        [Route("Products/AddReply")]
        public IActionResult AddReply(string commentId= "60ebcf8357ba50c5eee67029", string user="علی", string text="بلیییی")
        {
            return Json(_commentService.AddReply(commentId, user, text));
        }
      
    }
}
