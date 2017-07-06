using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>(Console.ReadLine()
                                                    .Split()
                                                    .Select(int.Parse));

            int n = int.Parse(Console.ReadLine());
            Predicate<int> isDivisibleByN = num => num % n == 0;

            foreach (var num in nums)
            {
                if(!isDivisibleByN(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
