using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            Func<int[], int[]> add = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x - 1).ToArray();
            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            while((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = add(nums);
                        break;
                    case "multiply":
                        nums = multiply(nums);
                        break;
                    case "subtract":
                        nums = subtract(nums);
                        break;
                    case "print":
                        print(nums);
                        break;
                }
            }

        }
    }
}
