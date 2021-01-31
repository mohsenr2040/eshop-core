using eshop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Sellers
{
    public class SCategory:BaseEntity
    {
        public string Name { get; set; }
        public virtual SCategory ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public SCategoryType  SCategoryType { get; set; }
        //sub cat
        public virtual ICollection<SCategory> SubCategories { get; set; }
    }

    public enum SCategoryType
    {
        Sell = 1,
        Service = 2,
    }
}
