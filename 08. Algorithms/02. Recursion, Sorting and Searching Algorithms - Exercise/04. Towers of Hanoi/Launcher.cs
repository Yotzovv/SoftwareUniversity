using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Towers_of_Hanoi
{
    class Launcher
    {
        private static Stack<int> source = new Stack<int>();
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        private static int steps = 0;

        static void Main(string[] args)
        {
            int bottomDisk = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, bottomDisk).Reverse());

            PrintRods();
            MoveDisks(bottomDisk, source, destination, spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if(bottomDisk == 1)
            {
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                steps++;
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                PrintRods();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}
