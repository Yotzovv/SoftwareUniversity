using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Box<dynamic>> elements = new List<Box<dynamic>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = int.Parse(Console.ReadLine());

            Box<dynamic> box = new Box<dynamic>(input);
            elements.Add(box);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Swapper<List<string>>.Swap(elements, indexes[0], indexes[1])
                             .ForEach(e => Console.WriteLine(e));
    }
}