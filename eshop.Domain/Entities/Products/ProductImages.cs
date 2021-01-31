using eshop.Domain.Entities.Commons;

namespace eshop.Domain.Entities.Products
{
    public class ProductImages:BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public string Src { get; set; }
    }
}
