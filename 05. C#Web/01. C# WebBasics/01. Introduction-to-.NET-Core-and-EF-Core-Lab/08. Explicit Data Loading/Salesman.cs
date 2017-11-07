using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Salesman : Customer
{
    public Salesman(string name, int id) : base (name, id)
    {
        Customers = new List<Customer>();
    }

    public List<Customer> Customers { get; set; }
}
