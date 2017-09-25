using Microsoft.EntityFrameworkCore;
using System;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
                    .HasOne(emp => emp.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(emp => emp.DepartmentId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
    }
}