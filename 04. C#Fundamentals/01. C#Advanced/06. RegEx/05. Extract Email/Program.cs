using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.Extract_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=[\s])([a-zA-Z])([A-z.-]+?)([A-Za-z])@([A-z][A-z-.]+)(\.)([A-z]+)";
            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
