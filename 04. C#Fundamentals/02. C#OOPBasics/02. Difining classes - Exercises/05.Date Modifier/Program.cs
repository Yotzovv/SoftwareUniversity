using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secDate = Console.ReadLine();

            DateModifier.CalculateDaysBetween(firstDate, secDate);
        }
    }
}
