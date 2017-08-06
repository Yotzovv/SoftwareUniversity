using System;

namespace _03.Card_Power
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            Card card = new Card(rank, suit);

            Console.WriteLine($"Card name: {card.Rank} of {card.Suit}; Card power: {card.GetPower()}");
        }
    }
}
