using JudgeApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JudgeApp.Data
{
    public class JudgeAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-52OK68M\\SQLEXPRESS;Database=JudgeAppExam;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasMany(s => s.Submissions);

            builder.Entity<Contest>()
                   .HasMany(s => s.Submissions);

            builder.Entity<Submission>()
                   .HasOne(c => c.Contest);
        }
    }
}
