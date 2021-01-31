using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Payment;
using EndPoint.Site.Utilities;
using eshop.Application.Services.Carts;
using eshop.Application.Services.Orders.Commands.AddNewOrder;
using eshop.Application.Services.Payments.Commands.AddPayment;
using eshop.Application.Services.Payments.Queries.GetPayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize(Roles ="Customer,Seller,Admin")]
    public class PaymentController : Controller
    {
        private readonly IAddPaymentService _addPaymentService;
        private readonly ICartService _cartService;
        private readonly CookiesManager cookiesManager;
        private readonly IGetPaymentService _getPaymentService;
        private readonly IAddNewOrderService _addNewOrderService;

        //zarinpal
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;

        public PaymentController(IAddPaymentService addPaymentService,ICartService cartService, 
            IGetPaymentService getPaymentService, IAddNewOrderService addNewOrderService)
        {
            _addPaymentService = addPaymentService;
            _cartService = cartService;
            _getPaymentService = getPaymentService;
            cookiesManager = new CookiesManager();
            _addNewOrderService = addNewOrderService;
            //zarinpal
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index()
        {
            var BrowserId = cookiesManager.GetBrowserId(HttpContext);
            string userId = ClaimUtility.GetUserId(HttpContext.User);
            var amount = int.Parse(_cartService.GetMyCart(BrowserId,userId).Data.TotalPrice.ToString());

            if(amount>0)
            {
                var Payment = _addPaymentService.Execute(amount, userId);

                // Send to pay in zarinpal
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09139738530",
                    CallbackUrl = $"https://localhost:44304/payment/verify?guid={Payment.Data.Guid}",
                    Description = "پرداخت فاکتور شماره " + Payment.Data.PaymentId,
                    Email = Payment.Data.Email,
                    Amount = Payment.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
           
            else
            {
                return RedirectToAction("Index", "Cart");
            }
            return  View();

        }

        public async Task<IActionResult> Verify(Guid guid ,string authority,string Status)
        {
            var Payment1 = _getPaymentService.Execute(guid).Data;
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = Payment1.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);


            string UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), UserId);

            if(verification.Status==100)
            {
                _addNewOrderService.Execute(new RequestAddNewOrderDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId,
                    PaymentId = Payment1.PaymentId,
                    Authority= authority,
                    RefId= verification.RefId,
                }
                );

                //redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else
            {

            }
            return View();
        }
    }
}
