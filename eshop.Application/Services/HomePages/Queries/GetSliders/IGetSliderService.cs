
using eshop.Common.Dto;
using System.Collections.Generic;

namespace eshop.Application.Services.HomePages.Queries.GetSliders
{
    public interface IGetSliderService
    {
       ResultDto<List<SliderDto>> Execute();
    }
  
    public class SliderDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
