using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractQuotations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var hash = new HashSet<string>();

            var matches = Regex.Matches(input, @"'.*?'|"".*?""");

            foreach (var match in matches)
            {
                var m = Regex.Match(match.ToString(), @"[^('|"")]+");
                hash.Add(m.ToString());
            }

            foreach (var item in hash)
            {
                Console.WriteLine(item);
            }
        }
    }
}
