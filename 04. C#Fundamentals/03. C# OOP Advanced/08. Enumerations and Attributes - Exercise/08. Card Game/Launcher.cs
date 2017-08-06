using _08.Card_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Card_Game
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player(Console.ReadLine());
            Player playerTwo = new Player(Console.ReadLine());

            List<Card> AllHands = new List<Card>();

            playerOne.AddCards(ReadCards(AllHands));
            AllHands.AddRange(playerOne.Cards);

            playerTwo.AddCards(ReadCards(AllHands));
            AllHands.AddRange(playerTwo.Cards);

            Player winner = playerOne.CompareTo(playerTwo) >= 0 ? playerOne : playerTwo;

            Console.WriteLine(winner);
        }

        public static List<Card> ReadCards(List<Card> AllHands)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < 5; i++)
            {
                string[] input = Console.ReadLine().Split();

                string rank = input[0];
                string suit = input.Count() == 3 ? input[2] : string.Empty;

                try
                {
                    Card card = new Card(rank, suit);

                    if (cards.Any(c => c.Rank.ToString() == rank && c.Suit.ToString() == suit) ||
                     AllHands.Any(c => c.Rank.ToString() == rank && c.Suit.ToString() == suit))
                    {
                        i--;
                        Console.WriteLine("Card is not in the deck.");
                    }
                    else
                    {
                        cards.Add(card);
                    }
                }
                catch
                {
                    i--;
                    Console.WriteLine("No such card exists.");
                }
            }

            return cards;
        }
    }
}
