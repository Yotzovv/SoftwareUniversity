using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Srabsko_Unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([a-zA-Z].*)[\s]@([a-zA-Z].*?)[\s](\d*)[\s](\d*)";
            var concerts = new Dictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    continue;
                }

                var match = Regex.Match(input, pattern);

                string singer = match.Groups[1].Value;
                string city = match.Groups[2].Value;
                int ticketPrice = int.Parse(match.Groups[3].Value);
                int soldTickets = int.Parse(match.Groups[4].Value);

                if(!concerts.Any(c => c.Key == city))
                {
                    concerts[city] = new Dictionary<string, int>();
                }

                if(!concerts[city].Any(s => s.Key == singer))
                {
                    concerts[city][singer] = 0;
                }

                concerts[city][singer] += ticketPrice * soldTickets;
            }

            foreach (var concert in concerts)
            {
                Console.WriteLine(concert.Key);

                foreach (var singer in concert.Value.OrderByDescending(m => m.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
