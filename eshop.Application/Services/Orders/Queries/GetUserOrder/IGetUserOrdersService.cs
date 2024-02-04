
using eshop.Common.Dto;
using eshop.Domain.Entities.Orders;
using System.Collections.Generic;

namespace eshop.Application.Services.Orders.Queries.GetUserOrder
{
    public interface IGetUserOrdersService
    {
        ResultDto<List<GetUserOrdersDto>> Execute(string UserId);
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
