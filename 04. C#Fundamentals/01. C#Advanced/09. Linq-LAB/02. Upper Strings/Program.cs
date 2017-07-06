using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Upper_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            words.Select(w => w.ToUpper())
                 .ToList()
                 .ForEach(w => Console.Write(w + " "));                        
        }
    }
}
