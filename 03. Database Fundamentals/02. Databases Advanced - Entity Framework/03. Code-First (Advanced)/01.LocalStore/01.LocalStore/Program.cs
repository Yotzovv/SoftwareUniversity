using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LocalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsContext context = new ProductsContext();

            Products product = context.Products.Find(1);

            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
