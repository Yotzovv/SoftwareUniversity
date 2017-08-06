using _02.Card_Rank;
using Enumerations_and_Attributes___Exercise;
using System;

namespace _03.Card_Power
{
    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = (Ranks) Enum.Parse(typeof(Ranks), rank);
            this.Suit = (Suits) Enum.Parse(typeof(Suits), suit);
        }

        
        public int GetPower() => (int)this.Rank + (int)this.Suit;
        
        public Ranks Rank { get; private set; } 
        
        public Suits Suit { get; private set; }
    }
}
