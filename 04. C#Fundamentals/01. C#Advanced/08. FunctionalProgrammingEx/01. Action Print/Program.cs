using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Action<string> printer = s => Console.WriteLine(s);

            foreach (var item in input)
            {
                printer(item);
            }
        }
    }
}
