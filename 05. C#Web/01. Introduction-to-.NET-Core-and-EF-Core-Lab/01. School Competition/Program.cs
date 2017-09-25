using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._School_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var subject = tokens[1];
                var pts = int.Parse(tokens[2]);

                if (!result.ContainsKey(name))
                {
                    result[name] = new Dictionary<string, int>();
                }

                if (!result[name].ContainsKey(subject))
                {
                    result[name][subject] = 0;
                }

                result[name][subject] += pts;
            }

            foreach (var item in result.OrderByDescending(pts => pts.Value.Values.Sum()).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} [{string.Join(", ", item.Value.Keys.OrderBy(c => c))}]");
            }
        }
    }
}
