using eshop.Application.Services.HomePages.Queries.GetHomePageImages;
using eshop.Application.Services.HomePages.Queries.GetSliders;
using eshop.Application.Services.Products.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<GetHomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
        public List<ProductForSiteDto> HomeAppliance { get; set; }
    }
}
