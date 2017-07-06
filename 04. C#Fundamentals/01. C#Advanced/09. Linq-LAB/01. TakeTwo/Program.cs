using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TakeTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            int[] inRange = nums.Where(n => n >= 10 && n <= 20)
                                .Distinct()
                                .Take(2)
                                .ToArray();

            Console.WriteLine(string.Join(" ", inRange));
        }
    }
}
