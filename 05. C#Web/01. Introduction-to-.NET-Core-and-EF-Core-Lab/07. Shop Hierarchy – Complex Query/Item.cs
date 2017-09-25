using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Item
{
    public Item(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
        Reviews = new List<Review>();
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public decimal Price { get; set; }
    
    public List<Review> Reviews { get; set; }
}
