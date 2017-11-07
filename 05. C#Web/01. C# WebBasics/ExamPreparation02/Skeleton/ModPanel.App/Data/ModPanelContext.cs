using Microsoft.EntityFrameworkCore;
using ModPanel.App.Data.Models;

namespace ModPanel.App.Data
{
    public class ModPanelContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-52OK68M\\SQLEXPRESS;Database=ModPanelExam;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasIndex(u => u.Email)
                   .IsUnique();

            builder.Entity<User>()
                   .HasMany(p => p.Posts);

            builder.Entity<User>()
                   .HasMany(l => l.Logs);
        }
    }
}
