using System;
using System.Linq;

namespace _05._Combinations
{
    class Launcher
    {
        private static int[] combinations;
        private static int n;
        private static int k;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            GetCombinations();
        }

        private static void GetCombinations(int index = 0, int element = 1)
        {
            if (index == k)
            {
                if (!combinations.GroupBy(n => n).Any(group => group.Count() > 1))
                {
                    Console.WriteLine(string.Join(" ", combinations));
                }

                return;
            }

            for (int i = element; i <= n; i++)
            {
                combinations[index] = i;

                GetCombinations(index + 1, i);
            }
        }
    }
}
