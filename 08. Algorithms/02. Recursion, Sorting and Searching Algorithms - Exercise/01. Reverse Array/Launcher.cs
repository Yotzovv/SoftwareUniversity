using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Array
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ReverseArray(arr, arr.Length - 1);
        }

        private static void ReverseArray(int[] arr, int index)
        {
            if(index < 0)
            {
                return;
            }

            Console.Write(arr[index] + " ");

            ReverseArray(arr, index - 1);
        }
    }
}
