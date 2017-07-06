using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountSubstringOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string substring = Console.ReadLine().ToLower();

            Console.WriteLine(Regex.Matches(text, substring).Count);
        }
    }
}
