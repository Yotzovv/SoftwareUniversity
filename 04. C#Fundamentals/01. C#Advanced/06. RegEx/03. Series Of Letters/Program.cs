using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Series_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(.)\1+";
            string input = Console.ReadLine();

            var match = Regex.Replace(input, pattern, "$1");

            Console.WriteLine(match);

        }
    }
}
