using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Threeuple
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string[] input = ReadInput();
            ThreeTuple<string, string, string> first = new ThreeTuple<string, string, string>($"{input[0]} {input[1]}", input[2], input[3]);
            Console.WriteLine(first);

            input = ReadInput();
            bool isDrunk = input[2] == "drunk" ? true : false;
            ThreeTuple<string, int, bool> second = new ThreeTuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk);
            Console.WriteLine(second);

            input = ReadInput();
            ThreeTuple<string, double, string> third = new ThreeTuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(third);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine().Split(new[] { ' ' });
        }
    }
}
