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
            string kword = Console.ReadLine();
            string text = Console.ReadLine();

            var matches = Regex.Matches(text, $@"[^.!?]* ({kword}) ([^.!?])+.");

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}