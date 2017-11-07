using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<AlbumsPictures> AlbumsPictures { get; set; }
    public DbSet<UsersAlbums> UsersAlbums { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(@"Server=DESKTOP-52OK68M\SQLEXPRESS;Database=TestDb;Integrated Security=True;");
        base.OnConfiguring(builder);
    }
}
