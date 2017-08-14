namespace BookShopSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}