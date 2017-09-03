using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";
            string input;

            while ((input = Console.ReadLine()) != "Over!")
            {
                int n = int.Parse(Console.ReadLine());
                var match = Regex.Match(input, pattern);
                StringBuilder sb = new StringBuilder();

                if (match.Success && match.Groups[2].Length == n)
                {
                    var indexes = Regex.Replace(match.Groups[1].Value + match.Groups[3].Value, @"\D*", string.Empty);

                    foreach (var index in indexes)
                    {
                        if (int.Parse(index.ToString()) >= match.Groups[2].Length || int.Parse(index.ToString()) < 0)
                        {
                            sb.Append(' ');
                            continue;
                        }

                        sb.Append(match.Groups[2].Value[int.Parse(index.ToString())]);
                    }

                    Console.WriteLine($"{match.Groups[2].Value} == {sb}");
                }
            }
        }
    }
}
