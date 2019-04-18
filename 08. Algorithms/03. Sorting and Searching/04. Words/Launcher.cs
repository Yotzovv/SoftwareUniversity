using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Words
{
    class Launcher
    {
        private static char[] input;
        private static int counter;
        private static HashSet<string> result = new HashSet<string>();

        static void Main(string[] args)
        {
            input = Console.ReadLine().ToCharArray();

            if (hasNoConsecutives())
            {
                Factoriel();
            }
            else
            {
                Permuatete(0, input.Length - 1);
                Console.WriteLine(result.Count);
            }
        }

        private static void Permuatete(int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                Swap(ref input[i], ref input[startIndex]);
                Permuatete(startIndex + 1, endIndex);
                Swap(ref input[i], ref input[startIndex]);

                if (hasNoConsecutives())
                {
                    counter++;
                    result.Add(string.Join("", input));
                }
            }
        }

        private static void Factoriel()
        {
            Console.WriteLine(
                Enumerable.Range(1, input.Length).Aggregate((a, b) => a * b));
        }

        private static bool hasNoConsecutives()
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] == input[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap(ref char l, ref char r)
        {
            if (l != r)
            {
                l ^= r;
                r ^= l;
                l ^= r;
            }
        }
    }
}
