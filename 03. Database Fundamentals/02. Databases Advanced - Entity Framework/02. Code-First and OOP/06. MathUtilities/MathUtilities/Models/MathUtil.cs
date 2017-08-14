using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilities.Models
{
    class MathUtil
    {
        public static void Sum(float f, float s)
        {
            Console.WriteLine($"{(f+s):f2}");
        }

        public static void Subtract(float f, float s)
        {
            Console.WriteLine($"{(f - s):f2}");
        }

        public static void Multiply(float f, float s)
        {
            Console.WriteLine("{0:f2}", f*s);
        }

        public static void Divide(float f, float s)
        {
            Console.WriteLine("{0:f2}", f/s);
        }

        public static void Percentage(float totalNum, float percentOfNum)
        {
            Console.WriteLine("{0:f2}", totalNum * (percentOfNum / 100));
        }
    }
}
