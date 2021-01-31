using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MD.PersianDateTime.Core;

namespace eshop.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public  interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }

    public class GetOrdersForAdminService: IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .Where(p => p.OrderState == orderState)
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new OrdersDto()
                {
                    OrderDate =new PersianDateTime(p.InsertTime).ToShortDateTimeString(),
                    OrderId = p.Id,
                    OrderState =p.OrderState,
                    ProductCount = p.OrderDetails.Count,
                    PaymentId=p.PaymentId,
                    UserId=p.UserId,
                }).ToList();

            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }


    public class OrdersDto
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int PaymentId { get; set; }
        public string UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }
    }
}
