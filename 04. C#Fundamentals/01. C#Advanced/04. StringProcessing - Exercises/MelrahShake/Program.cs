using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Trim().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int a = int.Parse(nums[0]);
            float b = float.Parse(nums[1]);
            float c = float.Parse(nums[2]);

            var binaryA = Convert.ToString(a, 2).PadLeft(10, '0').Substring(0, 10);
            var hex = a.ToString("X");

            Console.WriteLine(string.Format("|{0, -10}|{1}|{2, 10:f2}|{3, -10:f3}|", hex, binaryA, b, c));
        }
    }
}
