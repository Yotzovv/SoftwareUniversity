using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_by_First_and_Last_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();
            List<string> namez = new List<string>();

            while(input[0] != "END")
            {
                if(input[0].CompareTo(input[1]) == -1)
                {
                    namez.Add(input[0] + " " + input[1]);
                }
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
            }

            namez.ForEach(n => Console.WriteLine(n));
        }
    }
}
