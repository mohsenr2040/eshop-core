using eshop.Application.Services.Payments.Queries.GetPaymentForAdmin;
using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MD.PersianDateTime.Core;

namespace eshop.Infrastructure.Services.Payments.Queries
{
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
                    PaymentId = r.Id,
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
}
