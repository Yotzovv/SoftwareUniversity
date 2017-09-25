using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string name, int id)
    {
        Id = id;
        Name = name;
        Orders = new List<Order>();
        Reviews = new List<Review>();
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public List<Order> Orders { get; set; }

    public List<Review> Reviews { get; set; }

    public Salesman Salesman { get; set; }
}
