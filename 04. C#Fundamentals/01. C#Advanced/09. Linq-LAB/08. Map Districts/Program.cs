using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Map_Districts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            int min = int.Parse(Console.ReadLine());

            foreach (var item in input)
            {
                var city = item.Substring(0, 3);
                int population = int.Parse(item.Split(':')[1]);

                input.Wherei
            }
        }
    }
}
