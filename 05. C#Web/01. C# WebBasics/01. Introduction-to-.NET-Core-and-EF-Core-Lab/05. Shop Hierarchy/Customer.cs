using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
