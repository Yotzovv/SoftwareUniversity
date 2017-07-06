using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName = string.Empty;
            string pattern = @"[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+";

            var names = new List<string>();

            while((fullName = Console.ReadLine()) != "end")
            {
                var match = Regex.Match(fullName, pattern);

                Console.WriteLine(match);
            }
        }
    }
}
