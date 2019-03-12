using System;
using System.Linq;

namespace _01._Recursive
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();

            Console.WriteLine(Sum(arr, 0));
        }

        private static int Sum(int[] array, int index)
        {
            if (array.Length > index)
            {
                return array[index] + Sum(array, index + 1);
            }

            return 0;
        }
    }
}
