using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class SsCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
