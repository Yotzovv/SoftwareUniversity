using CarDealer.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Web
{
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sale>()
                   .HasOne(s => s.Car)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CarId);

            builder.Entity<Sale>()
                   .HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId);

            builder.Entity<Supplier>()
                   .HasMany(p => p.Parts)
                   .WithOne(s => s.Supplier)
                   .HasForeignKey(s => s.SupplierId);

            builder.Entity<PartCar>()
                   .HasKey(pc => new { pc.PartId, pc.CarId });

            builder.Entity<PartCar>()
                   .HasOne(pc => pc.Car)
                   .WithMany(c => c.Parts)
                   .HasForeignKey(pc => pc.CarId);

            builder.Entity<PartCar>()
                   .HasOne(pc => pc.Part)
                   .WithMany(c => c.Cars)
                   .HasForeignKey(pc => pc.CarId);
        }
    }
}
