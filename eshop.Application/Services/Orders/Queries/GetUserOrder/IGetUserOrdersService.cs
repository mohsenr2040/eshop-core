using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Orders.Queries.GetUserOrder
{
    public interface IGetUserOrdersService
    {
        ResultDto<List<GetUserOrdersDto>> Execute(string UserId);
    }

    public class GetUserOrdersService: IGetUserOrdersService
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

    public class GetUserOrdersDto
    {
        public int OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public int PaymentId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }

}
