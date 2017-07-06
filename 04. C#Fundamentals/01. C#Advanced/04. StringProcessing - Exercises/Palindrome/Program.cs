
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Trim().Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> palindromes = new HashSet<string>();

            foreach (var word in text)
            {
                if (Enumerable.Range(0, word.Length / 2).All(e => word[e] == word[word.Length - e - 1]))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine("[" + string.Join(", ", palindromes.OrderBy(w => w)) + "]");
        }
    }
}
