using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Non_Digit_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine("Non-digits: " + Regex.Matches(input, "[^0-9]").Count);
        }
    }
}
