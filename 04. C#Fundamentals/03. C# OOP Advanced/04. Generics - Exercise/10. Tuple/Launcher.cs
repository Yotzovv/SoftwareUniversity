using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Tuple
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string[] firstLine = ReadInput();
            MyTuple<string, string> first = new MyTuple<string, string>($"{firstLine[0]} {firstLine[1]}", firstLine[2]);
            Console.WriteLine(first);

            string[] secondLine = ReadInput();
            MyTuple<string, int> second = new MyTuple<string, int>(secondLine[0], int.Parse(secondLine[1]));
            Console.WriteLine(second);

            string[] thirdLine = ReadInput();
            MyTuple<int, double> third = new MyTuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));
            Console.WriteLine(third);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine().Split(new[] { ' ' });
        }
    }
}
