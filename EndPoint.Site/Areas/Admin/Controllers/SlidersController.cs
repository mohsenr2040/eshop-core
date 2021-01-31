using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.HomePages.AddNewSlider;
using eshop.Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]

    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;
        public SlidersController(IAddNewSliderService addNewSliderService)
        {
            _addNewSliderService = addNewSliderService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file,string link)
        { 
            _addNewSliderService.Execute(file, link);
            return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
        }
    }
}
