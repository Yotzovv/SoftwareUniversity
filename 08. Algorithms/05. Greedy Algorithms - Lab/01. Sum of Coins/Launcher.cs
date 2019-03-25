using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine()
                           .Split(new[] { ':', ',', ' ', }, StringSplitOptions.RemoveEmptyEntries)
                           .Where(s => s.All(char.IsNumber))
                           .Select(int.Parse)
                           .OrderByDescending(x => x);
        
        var coins = new Queue<int>(input);

        int sum = int.Parse(Console.ReadLine()
                                   .Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .FirstOrDefault(x => x.All(char.IsNumber)));

        var takenCoins = new List<int>();

        while (takenCoins.Sum() != sum)
        {
            if (takenCoins.Sum() + coins.Peek() > sum)
            {
                coins.Dequeue();
                continue;
            }

            takenCoins.Add(coins.Peek());
        }

        Console.WriteLine($"Number of coins to take: {takenCoins.Count}");

        foreach (var coin in takenCoins.Distinct())
        {
            var coinsCount = takenCoins.Where(c => c == coin).Count();

            Console.WriteLine($"{coinsCount} coin{(coinsCount == 1 ? "" : "s")} with value {coin}");
        }
    }
}