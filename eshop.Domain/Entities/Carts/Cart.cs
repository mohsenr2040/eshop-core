using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Carts
{
    public class Cart:BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
