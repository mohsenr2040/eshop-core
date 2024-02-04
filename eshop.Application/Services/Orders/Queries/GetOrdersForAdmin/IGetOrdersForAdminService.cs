
using eshop.Common.Dto;
using eshop.Domain.Entities.Orders;
using System.Collections.Generic;

namespace eshop.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public  interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
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
