using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Number_Wars
{
    class Program
    {
        static Queue<Card> firstPlayer = new Queue<Card>(GetCards());
        static Queue<Card> secPlayer = new Queue<Card>(GetCards());
        static int turnsCount = 0;


        static void Main(string[] args)
        {
            while (turnsCount < 1000000 && firstPlayer.Count > 0 && secPlayer.Count > 0)
            {
                try
                {
                    Card fPlayer = firstPlayer.Dequeue();
                    Card sPlayer = secPlayer.Dequeue();
                    Play(fPlayer, sPlayer);
                }
                catch { }

                turnsCount++;   
            }

            Print();
        }

        private static void Print()
        {
            if (firstPlayer.Count == 0 && secPlayer.Count == 0)
            {
                Console.WriteLine($"Draw after {turnsCount} turns");
            }
            else
            {
                string winner = firstPlayer.Count > secPlayer.Count ? "First player" : "Second player";
                Console.WriteLine($"{winner} wins after {turnsCount} turns");
            }
        }

        private static void Play(Card fPlayer, Card sPlayer)
        {
            if (fPlayer.Num == sPlayer.Num)
            {
                War(fPlayer, sPlayer);
            }
            else if (fPlayer.Num > sPlayer.Num)
            {
                firstPlayer.Enqueue(fPlayer);
                firstPlayer.Enqueue(sPlayer);
            }
            else
            {
                secPlayer.Enqueue(sPlayer);
                secPlayer.Enqueue(fPlayer);
            }
        }

        private static void War(Card fPlayer, Card sPlayer)
        {
            List<Card> fnewCards = DrawNewCards("first");
            fnewCards.Add(fPlayer);

            List<Card> snewCards = DrawNewCards("second");
            snewCards.Add(sPlayer);

            int fPower = fnewCards.Sum(c => c.Letter);
            int sPower = snewCards.Sum(c => c.Letter);

            if (fPower > sPower)
            {
                snewCards.AddRange(fnewCards);

                foreach (var card in snewCards.OrderByDescending(c => c.Num).ThenByDescending(c => c.Letter))
                {
                    firstPlayer.Enqueue(card);
                }
            }
            else if (fPower < sPower)
            {
                fnewCards.AddRange(snewCards);

                foreach (var card in fnewCards.OrderByDescending(c => c.Num).ThenByDescending(c => c.Letter))
                {
                    secPlayer.Enqueue(card);
                }
            }
            else
            {
                War(fPlayer, sPlayer);
            }
        }

        private static List<Card> DrawNewCards(string player)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < 3; i++)
            {
                if (player == "first")
                {
                    cards.Add(firstPlayer.Dequeue());
                }
                else if (player == "second")
                {
                    cards.Add(secPlayer.Dequeue());
                }
            }

            return cards;
        }

        private static List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();

            foreach (var token in Console.ReadLine().Split())
            {
                cards.Add(new Card(token));
            }

            return cards;
        }
    }
}

class Card
{
    public Card(string cardName)
    {
        this.Num = int.Parse(cardName.Remove(cardName.Length - 1));
        this.Letter = cardName.Last();
    }

    public int Num { get; set; }

    public char Letter { get; set; }
}