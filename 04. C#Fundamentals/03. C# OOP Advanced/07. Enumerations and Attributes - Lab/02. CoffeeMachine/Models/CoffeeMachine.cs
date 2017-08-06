using System;
using System.Collections.Generic;
using System.Linq;

public class CoffeeMachine
{
    private List<Coin> coins;
    private List<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coins = new List<Coin>();
        this.coffeesSold = new List<CoffeeType>();
    }

    public void BuyCoffee(string size, string type)
    {
        int price = (int)Enum.Parse(typeof(CoffeePrice), size);

        if (this.coins.Sum(c => (int)c) >= price)
        {
            CoffeeType coffee = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

            this.coffeesSold.Add(coffee);

            this.coins.Clear();
        }
    }

    public void InsertCoin(string coinInserted)
    {
        Coin coin = (Coin)Enum.Parse(typeof(Coin), coinInserted);
        this.coins.Add(coin);
    }

    public IEnumerable<CoffeeType> CoffeesSold { get { return this.coffeesSold; } }
}