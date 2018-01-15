using Market.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostOwner> PostOwner { get; set; }
        public DbSet<UserLogin> UserLoggs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                   .HasMany(o => o.Orders);

            builder.Entity<Order>()
                   .HasOne(x => x.Recipient);

            builder.Entity<Order>()
                   .HasOne(x => x.Sender);

            builder.Entity<Order>()
                   .HasOne(x => x.Product);

            builder.Entity<UserActivity>()
                   .HasOne(u => u.User)
                   .WithMany(a => a.UserActivities);

            builder.Entity<UserLogin>()
                   .HasOne(u => u.User)
                   .WithMany(l => l.UserLoggs);

            builder.Entity<ApplicationUser>()
                   .HasMany(x => x.Posts);
            
            builder.Entity<PostOwner>()
                   .HasKey(po => new { po.OwnerId, po.PostId });

            builder.Entity<PostOwner>()
                   .HasOne(o => o.Owner)
                   .WithMany(p => p.Posts)
                   .HasForeignKey(owner => owner.OwnerId);

            builder.Entity<Post>()
                   .HasOne(o => o.Owner);
                   
        }
    }
}
