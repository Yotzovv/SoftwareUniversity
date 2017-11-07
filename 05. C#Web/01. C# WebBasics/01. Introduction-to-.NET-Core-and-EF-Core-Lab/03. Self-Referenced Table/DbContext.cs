using Microsoft.EntityFrameworkCore;
using System;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
                    .HasOne(emp => emp.Manager)
                    .WithMany(e => e.Employees)
                    .HasForeignKey(emp => emp.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
    }
}