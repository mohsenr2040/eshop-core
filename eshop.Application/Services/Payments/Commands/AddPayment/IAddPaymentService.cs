
using eshop.Common.Dto;
using System;

namespace eshop.Application.Services.Payments.Commands.AddPayment
{
    public interface IAddPaymentService
    {
        ResultDto<ResultPaymentDto> Execute(int Amount, string UserId);
    }

    public class ResultPaymentDto
    {
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public int PaymentId { get; set; }
    }
}
