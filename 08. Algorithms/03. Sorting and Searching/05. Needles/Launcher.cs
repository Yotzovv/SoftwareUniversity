using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Needles
{
    class Launcher
    {
        private static int[] arrsCounts;
        private static List<int> numbers;
        private static int[] needles;
        private static List<int> output = new List<int>();

        static void Main(string[] args)
        {
            ReadInput();
            FindProperPlaces();

            Console.WriteLine(string.Join(" ", output));
        }

        private static void FindProperPlaces(int index = 0)
        {
            if (index >= needles.Count())
            {
                return;
            }

            int needle = needles[index];

            //For each needle find the left most index where it can be inserted.
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int number = numbers[i];

                if (number == 0)
                {
                    continue;
                }

                int difference = needle - number;
                int idx = i;

                if (difference == 0)
                {
                    if (i > 0)
                    {
                        if (numbers[i - 1] < needle)
                        {
                            idx = i;
                        }
                        else
                        {
                            idx = i - 1;
                        }

                        while (idx > 0 && numbers[idx - 1] == 0)
                        {
                            idx--;
                        }
                    }                   
                }
                else if (difference > 0)
                {
                    idx = i + 1;
                }
                else if (difference < 0 && i == 0)
                {
                    idx = 0;
                }

                if (difference >= 0 || difference < 0 && i == 0)
                {
                    numbers.Insert(idx, needle);
                    numbers.Remove(0);

                    output.Add(idx);
                    break;
                }
            }

            FindProperPlaces(++index);
        }

        private static void ReadInput()
        {
            arrsCounts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            needles = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
    }
}


//Code is magic, I'm a wizzard
//My code is poetry, I'm a true poet
//My poetry is magic, it will touch your hearth
//Your hearth is stollen, I am the thief
