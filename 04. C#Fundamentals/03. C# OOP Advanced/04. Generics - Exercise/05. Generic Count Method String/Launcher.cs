using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Box<string>> elements = new List<Box<string>>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Box<string>box = new Box<string>(Console.ReadLine());
            elements.Add(box);
        }

        Console.WriteLine
               (elements.First()
               .Compare(elements, (Console.ReadLine())));
    }
}