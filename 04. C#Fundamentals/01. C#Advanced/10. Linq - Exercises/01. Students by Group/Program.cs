using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students_by_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> namez = new List<string>();
            while (input[0] != "END")
            {
                if (input.Last() == "2")
                {
                    namez.Add(input[0] + " " + input[1]);
                }
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            namez.OrderBy(n => n)
                 .ToList()
                 .ForEach(n => Console.WriteLine(n));
      
        }
    }
}
