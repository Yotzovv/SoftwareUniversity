using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Replace_a_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"<a href=""(.+)"">(.+)<\/a>";

            while ((input = Console.ReadLine()) != "end")
            {
                if(Regex.Match(input, pattern).Success)
                {
                    input = Regex.Replace(input, pattern, "[URL href=\"$1\"]$2[/URL]");
                }
                Console.WriteLine(input);
            }

        }
    }
}
