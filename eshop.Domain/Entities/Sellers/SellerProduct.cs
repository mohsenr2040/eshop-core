using eshop.Domain.Entities.Carts;
using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Orders;
using eshop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Sellers
{
    public class SellerProduct:BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Seller Seller { get; set; }
        public int SellerId { get; set; }
        public int SellerPrice { get; set; }
        public int Inventory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
