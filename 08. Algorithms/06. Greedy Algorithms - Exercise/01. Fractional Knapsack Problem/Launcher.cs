using System;
using System.Collections.Generic;
using System.Linq;

class Launcher
{
    private static List<Item> items = new List<Item>();
    private static List<Item> result = new List<Item>();

    static void Main(string[] args)
    {
        int capacity = Console.ReadLine().Split().Select(int.Parse).Last();
        int itemsCount = Console.ReadLine().Split().Select(int.Parse).Last();

        ReadInput(itemsCount);
        TakeItems(capacity);
        Console.WriteLine($"Total price: {(result.Sum(p => p.Price)):F2}");
    }

    private static void TakeItems(int capacity, int index = 0)
    {
        if (index == items.Count || result.Sum(v => v.Weight) == capacity) { return; }

        var item = items.OrderByDescending(i => i.Price / i.Weight).ToArray()[index];

        var leftOver = capacity - result.Sum(v => v.Weight);
        double procent = Math.Round((leftOver / item.Weight) * 100, 2);
        procent = procent > 100 ? 100 : procent;

        Console.WriteLine($"Take {procent}% of item with price {item.Price} and weight {item.Weight}");

        result.Add(new Item
        {
            Price = (procent / 100) * item.Price,
            Weight = (procent / 100) * item.Weight
        });

        TakeItems(capacity, index + 1);
    }

    private static void ReadInput(int itemsCount, int index = 0)
    {
        if (index == itemsCount)
        {
            return;
        }

        var input = Console.ReadLine().Split("->").Select(double.Parse).ToArray();

        items.Add(new Item
        {
            Price = input[0],
            Weight = input[1]
        });

        ReadInput(itemsCount, index + 1);
    }

    private class Item
    {
        public double Price { get; set; }

        public double Weight { get; set; }
    }
}
