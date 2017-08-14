namespace _01.LocalStore
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }
        public virtual DbSet<Products> Products { get; set; }
    }
}