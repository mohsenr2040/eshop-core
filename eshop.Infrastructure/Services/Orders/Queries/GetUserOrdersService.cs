using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Application.Services.Orders.Queries.GetUserOrder;

namespace eshop.Infrastructure.Services.Orders.Queries
{
    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDataBaseContext _context;
        public GetUserOrdersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUserOrdersDto>> Execute(string UserId)
        {
            var orders = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .Where(o => o.UserId == UserId).OrderByDescending(o => o.Id)
                .ToList().Select(o => new GetUserOrdersDto()
                {
                    OrderId = o.Id,
                    OrderState = o.OrderState,
                    PaymentId = o.PaymentId,
                    OrderDetails = o.OrderDetails.Select(d => new OrderDetailsDto()
                    {
                        Count = d.Count,
                        Price = d.Price,
                        ProductId = d.ProductId,
                        ProductName = d.Product.Name,
                        OrderDetailId = d.Id,
                    }).ToList()
                }).ToList();

            return new ResultDto<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
}
