﻿using GameStore.App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.App.Data
{
    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-52OK68M\\SQLEXPRESS;Database=GameStoreExamDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasIndex(u => u.Email)
                   .IsUnique();

            builder.Entity<Order>()
                   .HasKey(o => new { o.UserId, o.GameId });

            builder.Entity<Order>()
                   .HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);

            builder.Entity<Order>()
                   .HasOne(o => o.Game)
                   .WithMany(g => g.Orders)
                   .HasForeignKey(o => o.GameId);
        }
    }
}
