using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Book_Shop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
            this.Price = price;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * (decimal) 1.3;
            }
        }
    }
}
