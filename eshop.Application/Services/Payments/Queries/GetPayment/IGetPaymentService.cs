using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services.Payments.Queries.GetPayment
{
    public interface IGetPaymentService
    {
        ResultDto<PaymentDto> Execute(Guid guid);
    }
    public class GetPaymentService : IGetPaymentService
    {
        private readonly IDataBaseContext _context;
        public GetPaymentService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<PaymentDto> Execute(Guid guid)
        {
            var Payment1 = _context.Payments.SingleOrDefault(r => r.Guid == guid);
            if(Payment1 != null)
            {
                return new ResultDto<PaymentDto>()
                {
                 
                    Data = new PaymentDto
                    {
                        PaymentId= Payment1.Id,
                        Amount = Payment1.Amount
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
           
        }
    }

    public class PaymentDto
    {
        public int Amount { get; set; }
        public int PaymentId { get; set; }
    }
}
