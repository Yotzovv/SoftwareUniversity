using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Students_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<string> names = new List<string>();

            while((input = Console.ReadLine().Split())[0] != "END")
            {
                if(int.Parse(input[2]) <= 24 && int.Parse(input[2]) >= 18)
                {
                    Console.WriteLine(string.Join(" ", input));
                }
            }
        }
    }
}
