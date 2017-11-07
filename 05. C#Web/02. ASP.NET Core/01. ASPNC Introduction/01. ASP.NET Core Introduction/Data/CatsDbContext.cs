using _01._ASP.NET_Core_Introduction.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _01._ASP.NET_Core_Introduction.Data
{
    public class CatsDbContext : DbContext
    {
        public CatsDbContext(DbContextOptions<CatsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
