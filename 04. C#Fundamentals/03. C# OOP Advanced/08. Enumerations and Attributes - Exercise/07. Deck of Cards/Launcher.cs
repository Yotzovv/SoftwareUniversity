using System;

namespace _07.Deck_of_Cards
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var ranks = Enum.GetNames(typeof(Ranks));
            var suits = Enum.GetNames(typeof(Suits));

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}
