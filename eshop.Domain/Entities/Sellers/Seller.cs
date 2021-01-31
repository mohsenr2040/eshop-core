using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Products;
using eshop.Domain.Entities.City;
using System;
using System.Collections.Generic;
using System.Text;
using eshop.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace eshop.Domain.Entities.Sellers
{
    public class Seller: BaseEntity
    {
        [MaxLength(25)]
        public string ShopName { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        [MaxLength(11)]
        public string Mobile { get; set; }
        [Required]
        public string UserName { get; set; }
        //public virtual eshop.Domain.Entities.City.City City { get; set; }
        //public int CityId { get; set; }
        public string Addrress { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<SellerProduct> SellerProducts { get; set; }
    }

}
