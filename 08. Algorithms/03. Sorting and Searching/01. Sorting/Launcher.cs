using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sorting
{
    class Launcher
    {
        private static int[] array;

        static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            array = MergeSort(array);

            Console.WriteLine(string.Join(" ", array));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            //Split array in half
            var arrOne = arr.Take(arr.Length / 2).ToArray();
            var arrTwo = arr.Skip(arr.Length / 2).Take(arr.Length / 2 + 1).ToArray();

            arrOne = MergeSort(arrOne);
            arrTwo = MergeSort(arrTwo);

            return Merge(arrOne, arrTwo);
        }

        private static int[] Merge(int[] arrOne, int[] arrTwo)
        {
            Queue<int> result = new Queue<int>();

            while(arrOne.Any() && arrTwo.Any())
            {
                if (arrOne[0] < arrTwo[0])
                {
                    result.Enqueue(arrOne[0]);
                    arrOne = arrOne.Skip(1).ToArray();
                }
                else
                {
                    result.Enqueue(arrTwo[0]);
                    arrTwo = arrTwo.Skip(1).ToArray();
                }
            }

            while(arrOne.Any())
            {
                result.Enqueue(arrOne[0]);
                arrOne = arrOne.Skip(1).ToArray();
            }

            while(arrTwo.Any())
            {
                result.Enqueue(arrTwo[0]);
                arrTwo = arrTwo.Skip(1).ToArray();
            }

            return result.ToArray();
        }
    }
}
