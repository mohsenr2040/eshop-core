using eshop.Common.Dto;
using Microsoft.AspNetCore.Http;
using eshop.Domain.Entities.HomePages;

namespace eshop.Application.Services.HomePages.Commands.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        ResultDto Execute(RequestAddHomePageImagesDto requestAdd);
    }

  

    public class RequestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
