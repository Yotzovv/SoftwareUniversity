    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _05.Min_Even_Number
    {
        class Program
        {
            static void Main(string[] args)
            {
                double[] nums = Console.ReadLine()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(double.Parse)
                                       .ToArray();
                try
                {
                    var minEven = nums.Where(n => n % 2 == 0)
                                  .Min();
                    Console.WriteLine($"{minEven:F2}");
                }
                catch
                {
                    Console.WriteLine("No match");
                }
            }
        }
    }
