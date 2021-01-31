using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.HomePages.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        ResultDto<List<GetHomePageImagesDto>> Execute();
    }
    public class GetHomePageImagesService: IGetHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetHomePageImagesDto>> Execute()
        {
            var homePageImages = _context.HomePageImages.ToList()
                .Select(h => new GetHomePageImagesDto()
                {
                    Id = h.Id,
                    ImageLocation = h.ImageLocation,
                    Link = h.Link,
                    Src = h.Src,
                }).ToList();

            return new ResultDto<List<GetHomePageImagesDto>>()
            {
                Data = homePageImages,
                IsSuccess = true,
            };
        }
    }
    public class GetHomePageImagesDto
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation  ImageLocation { get; set; }
    }

}
