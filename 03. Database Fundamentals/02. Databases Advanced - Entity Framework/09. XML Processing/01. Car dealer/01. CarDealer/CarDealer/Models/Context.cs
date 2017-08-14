namespace CarDealer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.Car_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Parts)
                .WithMany(e => e.Cars)
                .Map(m => m.ToTable("PartCars"));

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Parts)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Id);
        }
    }
}
