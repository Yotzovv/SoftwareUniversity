namespace Data
{
    using Models.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Reflection.Emit;

    public class SystemContext : DbContext
    {
        public SystemContext()
             : base("name=SystemContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SystemContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>()
                        .HasMany(p => p.PioneeringDiscoveries)
                        .WithMany(p => p.Pioneers)
                        .Map(t => t.ToTable("DiscoveriesPioneers")
                                   .MapLeftKey("Discovery")
                                   .MapRightKey("Pioneer"));
            modelBuilder.Entity<Astronomer>()
                        .HasMany(o => o.ObservationDiscoveries)
                        .WithMany(o => o.Observers)
                        .Map(t => t.ToTable("DiscoveriesObservers")
                                   .MapLeftKey("Discovery")
                                   .MapRightKey("Observer"));

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
    }
}