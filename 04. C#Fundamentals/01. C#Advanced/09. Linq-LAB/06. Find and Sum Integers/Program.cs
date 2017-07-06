using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Find_and_Sum_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var towns = new Dictionary<string, List<long>>();
            var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in elements)
            {
                var token = element.Split(':');
                var town = token[0];
                var population = long.Parse(token[1]);

                if(!towns.ContainsKey(town))
                {
                    towns[town] = new List<long>();
                }

                towns[town].Add(population);
            }

            var bound = long.Parse(Console.ReadLine());

            towns = towns.Where(t => t.Value.Sum() > bound)
                         .OrderByDescending(t => t.Value.Sum())
                         .ToDictionary(x => x.Key, x => x.Value);

            foreach (var town in towns)
            {
                var districs = town.Value
                                   .OrderByDescending(x => x)
                                   .Take(5);

                Console.WriteLine(string.Format($"{town.Key}: {string.Join(" ", districs)}"));
            }

        }
    }
}
