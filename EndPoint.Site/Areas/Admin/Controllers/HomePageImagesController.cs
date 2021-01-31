using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.HomePages.Commands.AddHomePageImages;
using eshop.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]

    public class HomePageImagesController : Controller
    {
        private readonly IAddHomePageImagesService _addHomePageImagesService;
        public HomePageImagesController(IAddHomePageImagesService addHomePageImagesService)
        {
            _addHomePageImagesService = addHomePageImagesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(IFormFile file,string link,ImageLocation imageLocation)
        {
            _addHomePageImagesService.Execute(new RequestAddHomePageImagesDto()
            {
                file = file,
                ImageLocation = imageLocation,
                Link = link,
            });
            return View();
        }
    }
}
