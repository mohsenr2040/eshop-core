using eshop.Domain.Entities.Sellers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Domain.Entities.City
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public virtual Province  Province { get; set; }
        public int ProvinceId { get; set; }
    }
}
