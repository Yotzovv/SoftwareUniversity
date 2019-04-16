using System;
using System.Linq;

namespace _02._Searching
{
    class Launcher
    {
        private static int[] array;
        private static int n;

        static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            n = int.Parse(Console.ReadLine());

            Console.WriteLine(
            BinarySearch(0, array.Count() - 1));
        }

        private static int BinarySearch(int startIndex, int endIndex)
        {
            int midIndex = startIndex + (endIndex - startIndex) / 2;

            if (n <= array.Last())
            {
                if (n == array[midIndex])
                {
                    return midIndex;
                }

                if (n < array[midIndex])
                {
                    return BinarySearch(startIndex, midIndex);
                }
                else if (n > array[midIndex])
                {
                    return BinarySearch(midIndex + 1, endIndex);
                }
            }

            return -1;
        }
    }
}
