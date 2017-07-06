using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split();

            string str1 = input[0];
            string str2 = input[1];

            int result = 0;

            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                result += str1[i] * str2[i];
            }

            for (int i = Math.Min(str1.Length, str2.Length); i < Math.Max(str1.Length, str2.Length); i++)
            {
                if(str1.Length > str2.Length)
                {
                    result += str1[i];
                }
                else
                {
                    result += str2[i];
                }
            }
            
            Console.WriteLine(result);
        }
    }
}
