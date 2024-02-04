
using eshop.Common.Dto;
using eshop.Domain.Entities.HomePages;
using System.Collections.Generic;

namespace eshop.Application.Services.HomePages.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        ResultDto<List<GetHomePageImagesDto>> Execute();
    }
  
    public class GetHomePageImagesDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation  ImageLocation { get; set; }
    }

}
