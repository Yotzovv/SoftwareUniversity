using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            string evenODD = Console.ReadLine();
            Predicate<int> isEven = n => n % 2 == 0;

            for (int i = nums[0]; i <= nums[1]; i++)            
            {
                switch (evenODD)
                {
                    case "even":
                        if (isEven(i)) Console.Write(i + " ");
                        break;
                    case "odd":
                        if (!isEven(i)) Console.Write(i + " ");
                        break;
                }
            }

        }
    }
}
