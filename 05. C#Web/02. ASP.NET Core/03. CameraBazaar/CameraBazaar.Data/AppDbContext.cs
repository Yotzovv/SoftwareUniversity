using CameraBazaar.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CameraBazaar.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasMany(u => u.Cameras)
                   .WithOne(c => c.User)
                   .HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}
