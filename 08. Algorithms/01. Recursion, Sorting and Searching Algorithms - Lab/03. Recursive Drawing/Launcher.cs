using System;
using System.Diagnostics;
using System.Linq;

namespace _03._Recursive
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Draw(input);
        }

        private static void Draw(int n)
        {
            if(n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            Draw(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
