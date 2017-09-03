using System;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var matches = Regex.Matches(input, @"\[[^\[]+<([0-9]+)REGEH([0-9]+)>[^]]+\]");
            int index = 0;

            foreach (Match match in matches)
            {
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    index += int.Parse(match.Groups[i].Value);
                    Console.Write((input[index % input.Length + index / input.Length]));
                }
            }
        }
    }
}