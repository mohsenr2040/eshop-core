using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.Commons
{
    class BaseEntityNotId
    {
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
