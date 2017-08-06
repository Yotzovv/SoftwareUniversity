using System;

namespace _03.Card_Power
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Card first = ReadCard();
            Card second = ReadCard();

            Console.WriteLine(first.CompareTo(second) > 0 ? first : second);
        }

        public static Card ReadCard()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();
            
            return new Card(rank, suit);
        }
    }
}
