using System;


public class Card
{
    public Card(string rank, string suit)
    {
        this.Rank = (Ranks) Enum.Parse(typeof(Ranks), rank);
        this.Suit = (Suits) Enum.Parse(typeof(Suits), suit);
    }

    public Ranks Rank { get; private set; }

    public Suits Suit { get; private set; }


    public int GetPower() => (int)this.Rank + (int)this.Suit;

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }
}