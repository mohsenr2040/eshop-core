using EndPoint.Site.Controllers;
using EndPoint.Site.Utilities;
using eshop.Application.Services.Carts;
using eshop.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Endpoint.Site.Test
{
    public class CartControllerTest
    {
        [Fact]
        public void Index()
        {
            List<CartItemDto> cartitems = new List<CartItemDto>()
            {
                new CartItemDto
                {
                    Id = 0,
                    ProductName = "washing machine",
                    ProductId = 3,
                    Count = 1,
                    Price = 10500000,
                    Images = "",
                    TotalPriceItem = 10500000
                }
            };
            ResultDto<CartDto> data = new ResultDto<CartDto>()
            {
                Data =
               new CartDto
               {
                   CartId = 0,
                   CartItems = cartitems,
                   TotalPrice = 10500000
               },
               IsSuccess=true
            };

            var moq = new Mock<ICartService>();

            moq.Setup(p => p.GetMyCart(Guid.Parse("0cd905ad-e101-4e4a-9401-3aaf4d81a4c4"), "700d83aa-6789-44b0-be82-4f660ec29cd3")).Returns(data);

            CartController cartController = new CartController(moq.Object);
            ViewResult  result=cartController.Index() as ViewResult;

            Assert.Equal(data.Data, result.Model);
        }
    }
}
