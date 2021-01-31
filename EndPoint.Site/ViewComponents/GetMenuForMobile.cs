using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.Common.Queries.GetMenuItemForMobile;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenuForMobile:ViewComponent
    {
        private readonly IGetMenuItemForMobileService _getMenuItemForMobileService;
        public GetMenuForMobile(IGetMenuItemForMobileService getMenuItemForMobileService)
        {
            _getMenuItemForMobileService = getMenuItemForMobileService;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "GetMenuForMobile", _getMenuItemForMobileService.Execute().Data);
        }
    }
}
