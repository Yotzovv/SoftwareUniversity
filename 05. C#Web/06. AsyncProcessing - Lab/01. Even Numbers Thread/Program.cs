using System;
using System.Linq;
using System.Threading;

namespace _01._Even_Numbers_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Thread evens = new Thread(() => PrintEvenNumbers(range[0], range[1]));
            evens.Start();
            evens.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
