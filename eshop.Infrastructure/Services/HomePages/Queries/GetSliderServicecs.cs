using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Application.Services.HomePages.Queries.GetSliders;

namespace eshop.Infrastructure.Services.HomePages.Queries
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<SliderDto>> Execute()
        {
            var _sliders = _context.Sliders
                .OrderByDescending(s => s.Id)
                .Select(s => new SliderDto
                {
                    Src = s.Src,
                    Link = s.Link
                }).ToList();
            return new ResultDto<List<SliderDto>>()
            {
                Data = _sliders,
                IsSuccess = true,
            };

        }
    }
}
