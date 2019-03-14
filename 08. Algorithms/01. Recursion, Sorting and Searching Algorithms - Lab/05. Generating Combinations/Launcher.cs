using System;
using System.Linq;

namespace _05._Generating
{
    class Launcher
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int border = int.Parse(Console.ReadLine());
            int[] vector = new int[border];

            int index = 0;

            GenCombs(set, vector, index, index);
        }

        private static void GenCombs(int[] set, int[] vector, int index, int border)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}