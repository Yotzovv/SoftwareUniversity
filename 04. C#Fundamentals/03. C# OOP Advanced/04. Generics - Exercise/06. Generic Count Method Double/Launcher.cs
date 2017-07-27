using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Box<double>> elements = new List<Box<double>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
            elements.Add(box);
        }

        Console.WriteLine
               (elements.First()
               .Compare(elements, (double.Parse(Console.ReadLine()))));
    }
}