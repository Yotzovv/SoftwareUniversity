using System;
using System.Linq;

namespace _04._Generating
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] vector = new int[input];

            Gen01(vector, 0);
        }

        private static void Gen01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;

                Gen01(vector, index + 1);
            }
        }
    }
}
