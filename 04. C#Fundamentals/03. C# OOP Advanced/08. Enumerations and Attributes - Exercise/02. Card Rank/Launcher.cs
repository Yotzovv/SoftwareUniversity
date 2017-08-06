using System;

namespace _02.Card_Rank
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var cards = Enum.GetNames(typeof(CardRanks));

            Console.WriteLine("Card Ranks:");

            foreach (var card in cards)
            {
                int value = (int) Enum.Parse(typeof(CardRanks), card);

                Console.WriteLine($"Ordinal value: {value}; Name value: {card}");
            }
        }
    }
}
