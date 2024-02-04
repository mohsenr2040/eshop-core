
using eshop.Common.Dto;
using Microsoft.AspNetCore.Http;

namespace eshop.Application.Services.HomePages.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file,string link);
    }
  


}
