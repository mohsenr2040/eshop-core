using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndPoint.Site.Models;
using eshop.Application.Services.HomePages.Queries.GetSliders;
using EndPoint.Site.Models.ViewModels.HomePages;
using eshop.Application.Services.HomePages.Queries.GetHomePageImages;
using eshop.Application.Interfaces.FacadPatterns;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using eshop.Application.Services.Products.Queries.GetCategories;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _getHomePageImagesService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger,IGetSliderService getSliderService,
            IGetHomePageImagesService getHomePageImagesService,
            IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _getHomePageImagesService = getHomePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            var categories = _productFacad.GetCategoriesService.Execute(null).Data;

            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _getHomePageImagesService.Execute().Data,
                //Camera = _productFacad.GetProductForSiteService.Execute("دوربین عکاسی", categories.SingleOrDefault(c => c.Name.Contains("دیجیتال")).Id, 1, 6, Ordering.theNewest).Data.Products,
                //Laptop = _productFacad.GetProductForSiteService.Execute("لپ تاپ", categories.SingleOrDefault(c => c.Name.Contains("دیجیتال")).Id, 1, 6, Ordering.theNewest).Data.Products,
                //Mobile = _productFacad.GetProductForSiteService.Execute("موبایل", categories.SingleOrDefault(c => c.Name.Contains("دیجیتال")).Id, 1, 6, Ordering.theNewest).Data.Products,
                //HomeAppliance = _productFacad.GetProductForSiteService.Execute("خانه", categories.SingleOrDefault(c => c.Name.Contains("خانه")).Id, 1, 6, Ordering.theNewest).Data.Products,
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
