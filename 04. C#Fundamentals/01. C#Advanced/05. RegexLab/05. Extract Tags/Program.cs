using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Extract_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> tags = new HashSet<string>();

            while (!(input = Console.ReadLine()).Contains("END"))
            {
                if (Regex.Match(input, "<.*?>").Success)
                {
                    foreach (var match in Regex.Matches(input, "<.*?>"))
                    {
                        tags.Add(match.ToString());
                    }
                }
            }

            foreach (var item in tags)
            {
                Console.WriteLine(item);
            }
        }
    }
}
