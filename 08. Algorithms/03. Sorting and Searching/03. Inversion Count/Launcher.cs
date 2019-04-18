using System;
using System.Linq;

namespace _03._Inversion_Count
{
    class Launcher
    {
        private static int[] array;
        private static int inversonsCount;

        static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            CountInversions(0);

            Console.WriteLine(inversonsCount);
        }

        private static void CountInversions(int currentIndex)
        {
            if (currentIndex < array.Length)
            {
                for (int i = currentIndex + 1; i < array.Length; i++)
                {
                    if (array[currentIndex] > array[i])
                    {
                        inversonsCount++;
                    }
                }

                CountInversions(++currentIndex);
            }
        }
    }
}
