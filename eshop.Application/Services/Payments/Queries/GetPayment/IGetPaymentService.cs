
using eshop.Common.Dto;
using System;

namespace eshop.Application.Services.Payments.Queries.GetPayment
{
    public interface IGetPaymentService
    {
        ResultDto<PaymentDto> Execute(Guid guid);
    }
   

    public class PaymentDto
    {
        public int Amount { get; set; }
        public int PaymentId { get; set; }
    }
}
