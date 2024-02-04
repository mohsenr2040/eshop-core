
using eshop.Common.Dto;
using System;
using System.Collections.Generic;

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
