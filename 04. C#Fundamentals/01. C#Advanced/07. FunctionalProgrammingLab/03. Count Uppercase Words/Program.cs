using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, bool> countUpcase = n => n.Any(char.IsUpper);
            input.Where(countUpcase)
                 .ToList()
                 .ForEach(n => Console.WriteLine(n));
        }
    }
}
