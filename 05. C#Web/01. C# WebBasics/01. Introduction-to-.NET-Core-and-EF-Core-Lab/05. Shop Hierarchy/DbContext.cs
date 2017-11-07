using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        Customers = new List<Customer>();
        Salesmen = new List<Salesman>();
    }

    public List<Customer> Customers { get; set; }

    public List<Salesman> Salesmen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
    }
}