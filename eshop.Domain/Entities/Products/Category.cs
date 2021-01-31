using eshop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Domain.Entities.Products
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        //sub cat
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<CategoryImage> CategoryImage { get; set; }
    }
  
}
