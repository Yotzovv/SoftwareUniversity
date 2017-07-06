using System;
using System.Linq;
namespace UnicodeChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string seq = Console.ReadLine();

            foreach (var item in seq)
            {
                Console.Write("\\u{0:x4}", (int)item);
            }
            Console.WriteLine();
        }
    }
}
