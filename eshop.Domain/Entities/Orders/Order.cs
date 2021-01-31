using eshop.Domain.Entities.Commons;
using eshop.Domain.Entities.Payments;
using eshop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Orders
{
    public class Order:BaseEntity
    {
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual Payment Payment { get; set; }
        public int PaymentId { get; set; }
        public OrderState OrderState { get; set; }
        public string Addrress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
