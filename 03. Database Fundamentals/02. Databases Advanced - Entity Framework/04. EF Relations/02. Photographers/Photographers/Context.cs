namespace Photographers
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }
    }
}