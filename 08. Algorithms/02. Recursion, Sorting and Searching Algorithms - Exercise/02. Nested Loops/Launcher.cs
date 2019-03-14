using System;

namespace _02._Nested_Loops
{
    class Launcher
    {
        private static int[] loops;

        static void Main(string[] args)
        {
            int loopsCount = int.Parse(Console.ReadLine());
            loops = new int[loopsCount];

            RecursiveLoops(0, loopsCount);            
        }

        private static void RecursiveLoops(int index, int loopsCount)
        {
            if(index == loopsCount)
            {
                Console.WriteLine(string.Join(" ", loops));
                return;
            }

            for (int i = 1; i <= loopsCount; i++)
            {
                loops[index] = i;
                RecursiveLoops(index + 1, loopsCount);
            }
        }
    }
}
