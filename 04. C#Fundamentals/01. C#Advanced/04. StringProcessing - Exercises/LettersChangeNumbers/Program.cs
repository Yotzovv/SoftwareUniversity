using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double result = 0;

            foreach (var word in input)
            {
                double number = double.Parse(Regex.Match(word, @"\d+").Value);
                int firstPos = char.ToUpper(word[0]) - 64;
                int secPos = char.ToUpper(word.Last()) - 64;

                if(char.IsUpper(word[0]))
                {
                    result += number / firstPos;
                }
                else
                {
                    result += number * firstPos;
                }

                if(char.IsUpper(word.Last()))
                {
                    result -= secPos;
                }
                else
                {
                    result += secPos;
                }
            }

            Console.WriteLine("{0:f2}", result);
        }
    }
}
