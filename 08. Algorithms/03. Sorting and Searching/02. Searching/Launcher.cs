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

                //Split scope
                if (n < array[midIndex])
                {
                    endIndex = midIndex;
                }
                else if (n > array[midIndex])
                {
                    startIndex = midIndex + 1;
                }

                return BinarySearch(startIndex, endIndex);
            }

            return -1;
        }
    }
}
