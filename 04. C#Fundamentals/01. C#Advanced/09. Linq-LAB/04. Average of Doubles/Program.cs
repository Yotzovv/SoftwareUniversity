using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_of_Doubles
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                                   .Split()
                                   .Select(double.Parse)
                                   .ToArray();
            Console.WriteLine($"{nums.Average():f2}");
        }
    }
}
