using _04.Froggy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(Console.ReadLine()
                                                  .Split(new[] { ',', ' ' }, 
                                                   StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToList());
            Lake lake = new Lake(list);
            lake.Print();
        }
    }
}
