using System.Collections.Generic;

public class Order
{
    public Order(int id)
    {
        Id = id;
        Items = new List<Item>();
    }

    public int Id { get; set; }

    public List<Item> Items { get; set; }
}

