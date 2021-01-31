using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Orders;
using eshop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Payments
{
    public class Payment : BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User {get;set;}
        public string UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
