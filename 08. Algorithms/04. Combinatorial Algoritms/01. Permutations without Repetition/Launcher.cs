using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Permutations
{
    class Program
    {
        private static char[] input;
        private static HashSet<string> output = new HashSet<string>();

        static void Main(string[] args)
        {
            input = Console.ReadLine().Where(x => !char.IsWhiteSpace(x)).ToArray();

            Permutate();

            Console.WriteLine(string.Join(Environment.NewLine, output.OrderBy(x => x)));
        }

        private static void Permutate()
        {
            for (int a = 0; a < input.Length; a++)
            {
                for (int b = 0; b < input.Length - 1; b++)
                {
                    Swap(ref input[b], ref input[b+1]);
                    output.Add(string.Join(" ", input));
                }
            }
        }

        private static void Swap(ref char v1, ref char v2)
        {
            if (v1 != v2)
            {
                v1 ^= v2;
                v2 ^= v1;
                v1 ^= v2;
            }
        }
    }
}
