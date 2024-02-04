using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using eshop.Domain.Entities.Orders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Application.Services.Orders.Commands.AddNewOrder;

namespace eshop.Infrastructure.Services.Orders.Commands
{
    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDataBaseContext _context;
        public AddNewOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewOrderDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.Payments.Find(request.PaymentId);
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c => c.SellerProduct)
                .ThenInclude(c => c.Product)
                .Where(c => c.Id == request.CartId).FirstOrDefault();

            requestPay.IsPayed = true;
            requestPay.RefId = request.RefId;
            requestPay.Authority = request.Authority;
            requestPay.PayDate = DateTime.Now;
            cart.Finished = true;

            var order = new Order
            {
                User = user,
                Payment = requestPay,
                OrderState = OrderState.Processing,
                Addrress = "",
            };
            _context.Orders.Add(order);

            List<OrderDetail> OrderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Product = item.Product,
                    Count = item.Count,
                    Order = order,
                    Price = item.SellerProduct.SellerPrice,
                    SellerProduct = item.SellerProduct,
                };
                OrderDetails.Add(orderDetail);
            }

            _context.OrderDetails.AddRange(OrderDetails);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "!",
            };
        }
    }
}
