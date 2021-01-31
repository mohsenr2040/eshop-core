using eshop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Products
{
    public class CategoryImage:BaseEntity
    {
        public string Src { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
