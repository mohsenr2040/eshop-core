using eshop.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Domain.Entities.HomePages
{
    public class Slider:BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
