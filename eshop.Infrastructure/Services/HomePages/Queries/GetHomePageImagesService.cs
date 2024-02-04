using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Application.Services.HomePages.Queries.GetHomePageImages;

namespace eshop.Infrastructure.Services.HomePages.Queries
{
    public class GetHomePageImagesService : IGetHomePageImagesService
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
}
