using ProductsShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            this.SoldProducts = new List<ProductDto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        
        public virtual List<ProductDto> SoldProducts { get; set; }
    }
}
