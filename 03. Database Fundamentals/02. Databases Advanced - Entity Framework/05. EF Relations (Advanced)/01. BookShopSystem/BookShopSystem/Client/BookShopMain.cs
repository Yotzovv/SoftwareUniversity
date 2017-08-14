using BookShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem
{
    class BookShopMain
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            context.SaveChanges();
        }
    }
}