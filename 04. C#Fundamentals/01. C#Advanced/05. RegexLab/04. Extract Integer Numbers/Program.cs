﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Extract_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, "[0-9]+");

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
