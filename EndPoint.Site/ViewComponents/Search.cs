using eshop.Application.Services.Common.Queries.GetCategory;
using eshop.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetSearchCategoryService _getSearchCategoryService;
        public Search(IGetSearchCategoryService getSearchCategoryService)
        {
            _getSearchCategoryService = getSearchCategoryService;
        }
        public IViewComponentResult Invoke()
        {
            //var categories = new SelectList(, "Id","Name");
            return View(viewName: "Search", _getSearchCategoryService.Execute().Data);
        }
    } 
    
}
