using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Sellers;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Products
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
        public virtual ICollection<SellerProduct> SellerProducts { get; set; }

    }
}
