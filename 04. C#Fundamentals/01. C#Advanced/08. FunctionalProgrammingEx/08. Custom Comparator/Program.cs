using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();

            Func<List<int>, List<int>> evens =
                n => n.Where(num => num % 2 == 0)
                      .OrderBy(x => x)
                      .ToList();

            Func<List<int>, List<int>> odds =
                n => n.Where(num => num % 2 != 0)
                      .OrderBy(x => x)
                      .ToList();

            evens(input).ForEach(x => Console.Write(x + " "));
            odds(input).ForEach(x => Console.Write(x + " "));
        }
    }
}
