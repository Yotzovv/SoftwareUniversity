using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            List<KeyValuePair<char, Queue<int>>> bunkers = new List<KeyValuePair<char, Queue<int>>>();
            string input;

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var tokens = input.Split();

                foreach (var token in tokens)
                {
                    if (token.All(char.IsDigit))
                    {
                        int weapons = int.Parse(token);

                        if (bunkers.Count > 1 && weapons + bunkers.First().Value.Sum() > bunkerCapacity)
                        {
                            string outputValue = bunkers.First().Value.Count == 0 ? "Empty" : string.Join(", ", bunkers.First().Value);

                            Console.WriteLine($"{bunkers.First().Key} -> {outputValue}");
                            bunkers.RemoveAt(0);
                        }

                        if (bunkers.Count == 1 && weapons <= bunkerCapacity)
                        {
                            while (bunkerCapacity - bunkers.First().Value.Sum() < weapons)
                            {
                                bunkers.First().Value.Dequeue();
                            }
                        }

                        if (weapons <= bunkerCapacity)
                        {
                            bunkers.First().Value.Enqueue(weapons);
                        }
                    }
                    else
                    {
                        if (!bunkers.Any(b => b.Key == char.Parse(token)))
                        {
                            var kv = new KeyValuePair<char, Queue<int>>(char.Parse(token), new Queue<int>());
                            bunkers.Add(kv);
                        }
                    }
                }
            }
        }
    }
}