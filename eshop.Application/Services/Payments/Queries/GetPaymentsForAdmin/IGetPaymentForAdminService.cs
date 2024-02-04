
using eshop.Common.Dto;
using System;
using System.Collections.Generic;

namespace eshop.Application.Services.Payments.Queries.GetPaymentForAdmin
{
    public interface IGetPaymentForAdminService
        {
            ResultDto<List<PaymentDto>> Execute();
        }
  
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public Guid Guid { get; set; }
        public String UserName { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPayed { get; set; }
        public string PayDate { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;
    }
    
}
