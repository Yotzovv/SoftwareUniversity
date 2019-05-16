using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Combinations
{
    class Program
    {
        private static char[] input;
        private static int n;
        private static HashSet<string> output;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Where(x => !char.IsWhiteSpace(x)).ToArray();
            n = int.Parse(Console.ReadLine());

            Combinate();
            Console.WriteLine(string.Join(Environment.NewLine, output));
        }

        private static void Combinate()
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int c = 0; c < input.Length; c++)
                {
                    output.Add($"{input[i]} {input[c]}");
                }
            }
        }
    }
}
