using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MD.PersianDateTime.Core;

namespace eshop.Application.Services.Payments.Queries.GetPaymentForAdmin
{
    public interface IGetPaymentForAdminService
        {
            ResultDto<List<PaymentDto>> Execute();
        }
    public class GetPaymentForAdminService : IGetPaymentForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetPaymentForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<PaymentDto>> Execute()
        {
            var Payment1 = _context.Payments
                .Include(r => r.User)
                .OrderByDescending(r => r.Id)
                .ToList()
                .Select(r => new PaymentDto()
                {
                    PaymentId=r.Id,
                    Guid = r.Guid,
                    Amount = r.Amount,
                    Authority = r.Authority,
                    IsPayed = r.IsPayed,
                    PayDate = new PersianDateTime(r.PayDate).ToShortDateTimeString(),
                    UserId = r.UserId,
                    UserName = r.User.FullName,
                    RefId = r.RefId,
                }).ToList();

            return new ResultDto<List<PaymentDto>>()
            {
                Data = Payment1,
                IsSuccess = true,
            };
        }
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
