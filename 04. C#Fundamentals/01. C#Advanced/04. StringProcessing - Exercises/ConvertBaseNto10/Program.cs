using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertBaseNto10
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine().Trim().Split().Select(BigInteger.Parse).ToArray();
            string b = input[0].ToString();
            string n = input[1].ToString();

            BigInteger result = 0;

            for (int i = n.Length - 1, pow = 0; i >= 0; i--, pow++)
            {
                BigInteger currentNum = BigInteger.Parse(n[i].ToString());
                BigInteger baseNum = BigInteger.Parse(b);

                result += BigInteger.Multiply(currentNum, BigInteger.Pow(baseNum, pow));
            }
            Console.WriteLine(result);
        }
    }
}
