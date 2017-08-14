using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LocalStore
{
    public class Products
    {
        public Products(string name, string distributor, string discription, decimal price)
        {
            this.Name = name;
            this.Distributor = distributor;
            this.Discription = discription;
            this.Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Distributor { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public double Weigth { get; set; }
        public int Quantity { get; set; }
    }
}
