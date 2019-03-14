using System;
using System.Linq;

namespace _03._Combinatio
{
    class Launcher
    {
        private static int[] combinations;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            combinations = new int[k];

            GetCombinations(n);
        }

        private static void GetCombinations(int n, int index = 0, int element = 1)
        {
            if(index == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = element; i <= n; i++)
            {
                combinations[index] = i;

                GetCombinations(n, index + 1, i);
            }
        }
    }
}
