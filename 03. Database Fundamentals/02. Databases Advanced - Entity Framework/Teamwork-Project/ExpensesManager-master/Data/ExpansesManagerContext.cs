namespace Data
{
    using Models.Models;
    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Linq;

    public class ExpansesManagerContext : DbContext
    {
        public ExpansesManagerContext()
            : base("name=ExpansesManagerContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<SubGroup> SubGroups { get; set; }
        public virtual DbSet<Element> Elements { get; set; }

       

    }
}