using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.Little_John
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrows = new Dictionary<string, int>();

            arrows["small"] = 0;
            arrows["medium"] = 0;
            arrows["large"] = 0;

            for (int i = 0; i < 4; i++)
            {
                string arrow = Console.ReadLine();

                foreach (var match in Regex.Matches(arrow, @">+-+>+"))
                { 
                    if(match.ToString().Contains(">>>----->>"))
                    {
                        arrows["large"]++;
                    }
                    else if (match.ToString().Contains(">>----->"))
                    {
                        arrows["medium"]++;
                    }
                    else if (match.ToString().Contains(">----->"))
                    {
                        arrows["small"]++;
                    }
                }
            }

            Encrypt(arrows["small"].ToString() + arrows["medium"].ToString() + arrows["large"].ToString());
        }

        private static void Encrypt(string concat)
        {
            int dec = int.Parse(concat);
            string binary = Convert.ToString(dec, 2);
            string concReved = binary + string.Join("", binary.Reverse());
            int result = Convert.ToInt32(concReved, 2);

            Console.WriteLine(result);
        }
    }
}
