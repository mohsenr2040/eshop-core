using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.Sellers;

namespace eshop.Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public virtual SellerProduct SellerProduct { get; set; }
        public int SellerProductId { get; set; }
    }
}
