using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eshop.Domain.Entities.City
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public ICollection<City>  Cities { get; set; }
    }
}
