using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using SimpleMvc.Domain;

namespace SimpleMvc.Data
{
    public class NotesDbContext : DbContext
    {        
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany<Note>();

            modelBuilder.Entity<Note>()
                        .HasOne<User>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=Test1;Integrated Security=True;");
        }

    }
}
