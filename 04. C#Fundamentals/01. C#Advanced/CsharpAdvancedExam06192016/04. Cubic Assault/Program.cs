using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            var meteors = new List<string>() { { "Green" }, { "Red" }, { "Black" } };
            var regions = new Dictionary<string, Dictionary<string, long>>();
            string input;

            while ((input = Console.ReadLine()) != "Count em all")
            {
                var tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var region = tokens[0];
                var meteor = tokens[1];
                var amount = int.Parse(tokens[2]);

                if (!regions.ContainsKey(region))
                {
                    regions[region] = new Dictionary<string, long>() { { "Green", 0 }, { "Red", 0 }, { "Black", 0 } };
                }

                regions[region][meteor] += amount;

                for (int i = 0; i < meteors.Count - 1; i++)
                {
                    var nextTypeCount = regions[region][meteors[i]] / 1000000;

                    if(nextTypeCount > 0)
                    {
                        regions[region][meteors[i + 1]] += nextTypeCount;
                        regions[region][meteors[i]] %= 1000000;
                    }
                }
            }

            var orderedRegions = regions.OrderByDescending(r => r.Value["Black"])
                                        .ThenBy(r => r.Key.Length)
                                        .ThenBy(r => r.Key)
                                        .ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);

                foreach (var meteor in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }
}
