using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Card_Game.Models
{
    public class Player : IComparable<Player>
    {
        private string name;
        private List<Card> cards;

        public Player(string name)
        {
            this.name = name;
            this.cards = new List<Card>();
        }

        public List<Card> Cards => this.cards;

        public string Name => this.name;


        public void AddCards(List<Card> cards) => this.cards.AddRange(cards);

        public Card WinningCard() => this.cards.OrderByDescending(c => c.GetPower()).First();

        public int CompareTo(Player other) => this.WinningCard().GetPower() - other.WinningCard().GetPower();
        
        public override string ToString() => $"{this.Name} wins with {this.WinningCard()}.";
    }
}
