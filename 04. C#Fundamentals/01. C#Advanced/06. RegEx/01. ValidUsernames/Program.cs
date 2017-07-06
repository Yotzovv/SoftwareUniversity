using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var usernames = new List<string>();
            var group = (input).Split(new[] { ' ', '\t', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in group)
            {
                if(char.IsLetter(item[0]))
                {
                    if(item.Any(c => !(char.IsLetter(c) || char.IsDigit(c) || char.Equals(c, '_'))))
                    {
                        continue;
                    }
                    else if(item.Length >= 3 && item.Length <= 25)
                    {
                        usernames.Add(item);
                    }
                }
            }

            var currUsernames = new List<string>();
            for (int a = 0; a < usernames.Count-1; a++)
            {
                currUsernames.Add(usernames[a] + " " + usernames[a + 1]);                
            }

            var result = currUsernames.OrderByDescending(l => l.Length).First().Split();
            
            Console.WriteLine(string.Join("\n", result));
        }
    }
}
