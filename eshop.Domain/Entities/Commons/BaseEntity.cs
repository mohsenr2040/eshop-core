using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
    }

    public abstract class BaseEntity: BaseEntity<int>
    {

    }
}
