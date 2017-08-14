using Photographers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            Tag tag = new Tag() { Label = "#Qica" };
            context.Tags.Add(tag);
            context.SaveChanges();
        }
    }
}
