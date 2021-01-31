using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.Payments.Queries.GetPaymentForAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PaymentController : Controller
    {
        private readonly IGetPaymentForAdminService _getPaymentForAdminService;
        public PaymentController(IGetPaymentForAdminService getPaymentForAdminService)
        {
            _getPaymentForAdminService = getPaymentForAdminService;
        }
        public IActionResult Index()
        {
            return View(_getPaymentForAdminService.Execute().Data);
        }
    }
}
