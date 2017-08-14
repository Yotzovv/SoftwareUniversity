namespace Photographers.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Photographers.Context context)
        {
            Photographer a = new Photographer()
            {
                Username = "PhotoSlayer_xXx",
                Password = "123456",
                Email = "daPhotographer@abv.bg",
                Birthdate = new DateTime(2004, 9, 6),
                RegisterDate = new DateTime(2004, 9, 7)
            };
            context.Photographers.AddOrUpdate(p => p.Username, a);
            context.SaveChanges();

            Picture fdobai = new Picture()
            {
                Title = "TukaSamFDobai",
                Caption = "f Dobai",
                PathInFileSystem = "asdasd"
            };
            context.Pictures.AddOrUpdate(d => d.Title, fdobai);

            Album asd = new Album()
            {
                Name = "Za Auschwitz",
                BackgroundColor = "#Ffff",
                IsPublic = true,
            };

            
            context.Albums.AddOrUpdate(w => w.Name, asd);
            context.SaveChanges();

            asd.Pictures.Add(fdobai);
            context.SaveChanges();

            PhotographerAlbum ph = new PhotographerAlbum()
            {
                Photographer_Id = a.Id,
                Album_Id = asd.Id,
                Role = Role.Viewer
            };

            asd.Photographers.Add(ph);
            context.PhotographerAlbums.Add(ph);
            Tag ftag = new Tag()
            {
                Label = "#asd"
            };

            context.Tags.AddOrUpdate(e => e.Label, ftag);
            ftag.Albums.Add(asd);
            context.SaveChanges();
        }
    }
}
