using System;

namespace _02._Recursi
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(Factoriel(input));
        }

        private static long Factoriel(int n)
        {
            if(n == 1)
            {
                return 1;
            }

            return n * Factoriel(n - 1);
        }
    }
}
