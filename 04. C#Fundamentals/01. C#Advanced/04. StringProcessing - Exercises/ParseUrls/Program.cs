using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ParseUrls
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Trim().Split().Select(BigInteger.Parse).ToArray();
            BigInteger b = input[0];
            BigInteger n = input[1];
            Stack<int> result = new Stack<int>();

            while (n != 0)
            {
                var remainder = n % b;
                n /= b;

                result.Push(int.Parse(remainder.ToString()));
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}