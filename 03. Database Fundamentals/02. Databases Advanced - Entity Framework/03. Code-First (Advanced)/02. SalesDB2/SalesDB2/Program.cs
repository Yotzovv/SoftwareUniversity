using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB2
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();
            Product p = new Product();
            p.Name = "Milk";
            p.Discription = "Liquid";

            context.Products.Add(p);
            context.SaveChanges();
        }
    }
}
