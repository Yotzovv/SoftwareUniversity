using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.Extract_Hyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @"href=""(.+)""\s";
            var websites = new List<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                var website = Regex.Match(input, pattern).Groups[1];
                websites.Add(website.ToString());
            }

            foreach (var item in websites)
            {
                Console.WriteLine(item);
            }
        }
    }
}
