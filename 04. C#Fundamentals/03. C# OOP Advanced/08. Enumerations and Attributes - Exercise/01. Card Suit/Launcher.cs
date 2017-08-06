using System;

namespace Enumerations_and_Attributes___Exercise
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var cards = Enum.GetNames(typeof(Cards));
            var names = Enum.GetNames(typeof(Cards));

            Console.WriteLine("Card Suits:");

            foreach (var card in cards)
            {
                int value = (int)Enum.Parse(typeof(Cards), card);

                Console.WriteLine($"Ordinal value: {value}; Name value: {card}");
            }
        }
    }
}
