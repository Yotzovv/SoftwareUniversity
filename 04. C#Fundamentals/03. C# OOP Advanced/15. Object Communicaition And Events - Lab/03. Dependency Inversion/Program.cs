using System;

namespace _03.Dependency_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if(input[0] == "mode")
                {
                    calculator.ChangeStrategy(char.Parse(input[1]));
                }
                else
                {
                    Console.WriteLine(calculator.PerformCalculation(int.Parse(input[0]), int.Parse(input[1])));
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
