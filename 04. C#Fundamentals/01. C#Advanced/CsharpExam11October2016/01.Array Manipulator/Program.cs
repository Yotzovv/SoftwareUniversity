using System;
using System.Linq;

namespace _01.Array_Manipulator
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            arr = (Console.ReadLine().Split().Select(int.Parse).ToArray());
            string input;

            while((input = Console.ReadLine().ToLower()) != "end")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var parameters = tokens.Skip(1).ToArray();

                if(command == "exchange")
                {
                    Exchange(parameters);
                }
                else if(command == "max")
                {
                    Max(parameters);
                }
                else if(command == "min")
                {
                    Min(parameters);
                }
                else if(command == "first")
                {
                    First(parameters);
                }
                else if(command == "last")
                {
                    Last(parameters);
                }
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        private static void Last(string[] parameters)
        {
            int count = int.Parse(parameters[0]);
            string type = parameters[1];

            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (type == "even")
            {
                var evens = arr.Where(r => r % 2 == 0).Reverse().Take(count).Reverse();
                Console.WriteLine("[" + string.Join(", ", evens) + "]");
            }
            else if(type == "odd")
            {
                var odds = arr.Where(r => r % 2 != 0).Reverse().Take(count).Reverse();
                Console.WriteLine("[" + string.Join(", ", odds) + "]");
            }
        }

        private static void First(string[] parameters)
        {
            int count = int.Parse(parameters[0]);
            string type = parameters[1];

            if(count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            if (type == "even")
            {
                var evens = arr.Where(r => r % 2 == 0).Take(count);
                Console.WriteLine("[" + string.Join(", ", evens) + "]");
            }
            else if(type == "odd")
            {
                var odds = arr.Where(r => r % 2 != 0).Take(count);
                Console.WriteLine("[" + string.Join(", ", odds) + "]");
            }
        }

        private static void Min(string[] parameters)
        {
            if(parameters[0] == "even")
            {
                if (!arr.Any(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxEven = arr.Where(x => x % 2 == 0).Min();

                Console.WriteLine(Array.LastIndexOf(arr, maxEven));
            }
            else if(parameters[0] == "odd")
            {
                if (!arr.Any(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxOdd = arr.Where(x => x % 2 != 0).Min();

                Console.WriteLine(Array.LastIndexOf(arr, maxOdd));
            }
        }

        private static void Max(string[] parameters)
        {
            if(parameters[0] == "even")
            {
                if(!arr.Any(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxEven = arr.Where(x => x % 2 == 0).Max();

                Console.WriteLine(Array.LastIndexOf(arr, maxEven));
            }
            else if(parameters[0] == "odd")
            {
                if (!arr.Any(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }

                var maxOdd = arr.Where(x => x % 2 != 0).Max(); 

                Console.WriteLine(Array.LastIndexOf(arr, maxOdd));
            }

        }

        private static void Exchange(string[] parameters)
        {
            int index = int.Parse(parameters[0]);

            if(index >= arr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            arr = arr.Skip(index + 1).Concat(arr.Take(index + 1)).ToArray();
        }
    }
}
