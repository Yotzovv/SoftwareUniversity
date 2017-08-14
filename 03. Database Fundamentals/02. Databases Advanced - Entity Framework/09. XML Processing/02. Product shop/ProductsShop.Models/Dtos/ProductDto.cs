using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models
{
    [Serializable]
    public class ProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Buyer { get; set; }
    }
}
