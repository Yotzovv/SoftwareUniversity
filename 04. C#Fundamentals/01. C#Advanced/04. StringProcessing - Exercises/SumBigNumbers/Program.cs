using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                text = Regex.Replace(text, word, new string('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}
