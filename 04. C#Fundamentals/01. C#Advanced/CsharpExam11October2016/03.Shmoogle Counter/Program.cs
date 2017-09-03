using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Shmoogle_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string pattern = @"(double|int) ([a-z]{1}[a-zA-Z]*)";
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            while ((line = Console.ReadLine()) != @"//END_OF_CODE")
            {
                if(!Regex.IsMatch(line, pattern))
                {
                    continue;
                }

                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    if(match.Groups[1].Value == "double")
                    {
                        doubles.Add(match.Groups[2].Value);
                    }
                    else if(match.Groups[1].Value == "int")
                    {
                        ints.Add(match.Groups[2].Value);
                    }
                }
            }

            var doublesOutput = doubles.Count > 0 ? string.Join(", ", doubles.OrderBy(x => x)) : "None";
            var intsOutput = ints.Count > 0 ? string.Join(", ", ints.OrderBy(x => x)) : "None";

            Console.WriteLine($"Doubles: {doublesOutput}");
            Console.WriteLine($"Ints: {intsOutput}");
        }
    }
}
