using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Site.Utilities;
using eshop.Application.Services.Orders.Queries.GetUserOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    [Authorize(Roles ="Admin,Operator,Customer,Seller")]
    
    public class OrdersController : Controller
    {
        private readonly IGetUserOrdersService _getUserOrdersService;
        public OrdersController(IGetUserOrdersService getUserOrdersService)
        {
            _getUserOrdersService = getUserOrdersService;
        }
        public IActionResult Index()
        {
            string UserId = ClaimUtility.GetUserId(User);
            return View(_getUserOrdersService.Execute(UserId).Data);
        }
    }
}
