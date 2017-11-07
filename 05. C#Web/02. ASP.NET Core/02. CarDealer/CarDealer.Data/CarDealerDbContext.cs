namespace CarDealer.Data
{
    using Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarDealerDbContext : IdentityDbContext<Use>
    {
        public CarDealerDbContext()
        { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sale>()
                   .HasOne(s => s.Car)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CatId);

            builder.Entity<Sale>()
                   .HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=ByTheCakeDb;Integrated Security=True;");
        }
    }
}
