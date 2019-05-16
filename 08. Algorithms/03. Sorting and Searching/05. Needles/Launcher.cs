using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Needles
{
    class Launcher
    {
        private static int[] arrsCounts;
        private static List<int> numbers;
        private static int[] needles;
        private static List<int> output = new List<int>();

        static void Main(string[] args)
        {
            ReadInput();
            FindProperPlaces();

            Console.WriteLine(string.Join(" ", output));
        }

        private static void FindProperPlaces(int index = 0)
        {
            if (index >= needles.Count())
            {
                return;
            }

            int needle = needles[index];

            int idx = numbers.Count;
            int previous = numbers[idx - 1];

            bool needToMoveLeft = (previous >= needle || previous == 0);

            while (needToMoveLeft)
            {
                if (idx <= 0)
                {
                    break;
                }

                int prev = numbers[idx - 1];
                needToMoveLeft = (prev >= needle || prev == 0);

                if (needToMoveLeft)
                {
                    --idx;
                }
            }

            numbers.Insert(idx, needle);
            numbers.Remove(0);

            output.Add(idx);

            FindProperPlaces(++index);
        }

        private static void ReadInput()
        {
            arrsCounts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
    }
}