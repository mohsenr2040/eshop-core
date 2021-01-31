using eshop.Application.Interfaces.Contexts;
using eshop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eshop.Domain.Entities.Carts;

namespace eshop.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(int ProductId,int SellerId, Guid BrowserId,string UserId);
        ResultDto RemoveFromCart(int ProductId, Guid BrowserId);
        ResultDto<CartDto> GetMyCart(Guid BrowserId,string UserId);
        ResultDto Add(int CartItemId);
        ResultDto LowOff(int CartItemId);
    }
    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);

            cartItem.Count++;
            
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto AddToCart(int ProductId, int SellerId, Guid BrowserId,string UserId)
        {
            var cart = _context.Carts.Where(c => c.BrowserId == BrowserId && c.UserId == UserId &&  c.Finished == false).FirstOrDefault();
            if(cart == null)
            {
                Cart Cart1 = new Cart()
                {
                    Finished=false,
                    BrowserId = BrowserId,

                };
                _context.Carts.Add(Cart1);
                _context.SaveChanges();
                cart = Cart1;
            }
            var product = _context.Products
                .Include(p => p.SellerProducts)
                .SingleOrDefault(p => p.Id == ProductId );

            var cartItem = _context.CartItems.Where(c => c.ProductId == ProductId && c.CartId == cart.Id).FirstOrDefault();
            if(cartItem!=null)
            {
                cartItem.Count = +1;
            }
            else
            {
                CartItem CartItem1 = new CartItem()
                {
                    Cart=cart,
                    Product = product,
                    Count = 1,
                    SellerProduct= product.SellerProducts.SingleOrDefault(s=>s.SellerId==SellerId),
                    Price = product.SellerProducts.SingleOrDefault(s=>s.SellerId==SellerId).SellerPrice,
                    
                };
                _context.CartItems.Add(CartItem1);
                _context.SaveChanges();
            }
           
            return new ResultDto
            {
                IsSuccess=true,
                Message=$"محصول {product.Name} با موفقیت به سبد خرید شما اضافه شد",
            };

        }

        public ResultDto<CartDto> GetMyCart(Guid BrowserId,string UserId)
        {
            var carts = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(c=>c.SellerProduct)
                .ThenInclude(c => c.Product)
                .ThenInclude(c => c.ProductImages)
                .Where(c => c.BrowserId == BrowserId && ((UserId != null && c.UserId != null) ? c.UserId == UserId : c.UserId == null) && c.Finished == false)
                .OrderByDescending(c => c.Id);

            foreach (var item in carts.ToList())
            {
                if ((DateTime.Now.Date.Day - item.InsertTime.Date.Day) > 10)
                {
                    item.Finished = true;
                    carts.ToList().Remove(item);
                    _context.SaveChanges();
                }
            }
            if (carts.Count() > 1)
            {

                foreach (var item in carts.ToList()[0].CartItems)
                {
                    item.CartId = carts.ToList()[1].Id;
                    carts.ToList()[1].CartItems.Add(item);
                }
                carts.ToList()[0].Finished = true;
                _context.SaveChanges();
            }
            var cart = carts.SingleOrDefault(c => c.Finished == false);


            if (cart == null)
            {
                return new ResultDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        CartItems = new List<CartItemDto>(),
                    }
                };
            }

            if(UserId !=null )
            {
                var user = _context.Users.Find(UserId);
                cart.User = user;
                _context.SaveChanges();
            }
            return new ResultDto<CartDto>
            {
                Data = new CartDto
                {
                    CartId=cart.Id,
                    CartItems = cart.CartItems.Select(c => new CartItemDto
                    {
                        Count = c.Count,
                        Price = c.SellerProduct.SellerPrice,
                        ProductName = c.Product.Name,
                        ProductId=c.Product.Id,
                        Id = c.Id,
                        Images = c.Product.ProductImages.FirstOrDefault().Src ?? "",
                        TotalPriceItem = c.SellerProduct.SellerPrice * c.Count,
                    }).ToList(),

                    TotalPrice = cart.CartItems.Sum(c => c.SellerProduct.SellerPrice * c.Count),
                },
                IsSuccess = true,
            };
        }

        public ResultDto LowOff(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            if(cartItem.Count>=1)
            {
                cartItem.Count--;
            }
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto RemoveFromCart(int cartItemId, Guid BrowserId)
        {
            var cartitem = _context.CartItems.Where(c => c.Cart.BrowserId == BrowserId && c.Id==cartItemId).FirstOrDefault();
            if(cartitem !=null)
            {
                cartitem.IsDeleted = true;
                cartitem.DeleteTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = $"محصول با موفقیت از سبد خرید شما حذف شد",
                };
            }
            else

            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "یافت نشد",
                };
            }
        }
    }
    public class CartDto
    {
        public int CartId { get; set; }
        public List<CartItemDto> CartItems { get; set; }
        public int TotalPrice { get; set; }
    }
    public class CartItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
        public int TotalPriceItem { get; set; }
    }

}
