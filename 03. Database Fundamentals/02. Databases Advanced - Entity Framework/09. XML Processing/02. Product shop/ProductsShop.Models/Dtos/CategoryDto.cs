using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public int ProductsCount { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal totalRevenue { get; set; }
    }
}
