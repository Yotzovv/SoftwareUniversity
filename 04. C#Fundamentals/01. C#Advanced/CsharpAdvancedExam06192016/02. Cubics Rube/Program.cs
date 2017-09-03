using System;
using System.Linq;

namespace _02.Cubics_Rube
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            var changedCells = 0;
            var particles = 0L;
            string input;

            while((input = Console.ReadLine()) != "Analyze")
            {
                var tokens = input.Split().Select(int.Parse).ToArray();

                if(tokens.Take(3).All(p => p >= 0 && p < dimension) && tokens[3] != 0)
                {
                    particles += tokens[3];
                    changedCells++;
                }
            }

            Console.WriteLine(particles);
            Console.WriteLine(Math.Pow(dimension, 3) - changedCells);
        }
    }
}
