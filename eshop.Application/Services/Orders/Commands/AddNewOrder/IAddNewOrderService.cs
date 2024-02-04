
using eshop.Common.Dto;

namespace eshop.Application.Services.Orders.Commands.AddNewOrder
{
    public  interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderDto request);
    }
    
    public class RequestAddNewOrderDto
    {
        public int CartId { get; set; }
        public int PaymentId { get; set; }
        public string UserId { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;
    }
}
