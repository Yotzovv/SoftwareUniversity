﻿using Microsoft.EntityFrameworkCore;

public class ByTheCakeDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
    {
        modelBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=ByTheCakeDb;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<OrderProduct>()
               .HasKey(op => new { op.OrderId, op.ProductId });

        builder.Entity<User>()
               .HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId);

        builder.Entity<Product>()
               .HasMany(pr => pr.Orders)
               .WithOne(op => op.Product)
               .HasForeignKey(op => op.ProductId);

        builder.Entity<Order>()
               .HasMany(o => o.Products)
               .WithOne(op => op.Order)
               .HasForeignKey(op => op.OrderId);     

    }
}
