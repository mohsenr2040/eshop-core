using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public class RequestAddNewProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; }
        public virtual List<IFormFile> Images { get; set; }
        public virtual List<AddNewProduct_Features> Features { get; set; }
    }



