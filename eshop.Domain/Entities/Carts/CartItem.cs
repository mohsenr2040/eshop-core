using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.Sellers;

namespace eshop.Domain.Entities.Carts
{
    public class CartItem : BaseEntity
    {
        public virtual Product Product{ get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public virtual SellerProduct SellerProduct { get; set; }
        public int SellerProductId { get; set; }
    }
}
