using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bounded_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int[] seq = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

            seq.Where(n => n >= range.Min() && n <= range.Max())
               .ToList()
               .ForEach(n => Console.Write(n + " "));
        }
    }
}
