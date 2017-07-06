using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                                    .Split(new[] { ',', ' ' },
                                    StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToList();

            Func<double, double> addVat = n => n + (n * 0.2);
            input.ForEach(n => Console.WriteLine($"{addVat(n):f2}"));
        }
    }
}
