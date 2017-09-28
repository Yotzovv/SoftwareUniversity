using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _04._Table_Users
{
    class Launcher
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
              // RefreshDatabase(context);
              // SeedDatabase(context);
               Tasks(context);
            }
        }

        private static void RefreshDatabase(Context context)
        {
            Console.WriteLine("Deleting database...");
            context.Database.EnsureDeleted();

            Console.WriteLine("Creating database...");
            context.Database.EnsureCreated();

            // Console.WriteLine("Migrating database...");
            // context.Database.Migrate();
        }

        private static void SeedDatabase(Context context)
        {
            SeedUsers(context);
            SeedFriends(context);
            SeedAlbums(context);
            SeedPictures(context);
            SeedAlbumsWithPictures(context);
        }

        private static void Tasks(Context context)
        {
            // ListAllUsersAndFriendsCount(context);
            // ListAllActiveUsersWithMoreThanFiveFriends(context);
            // ListAllAlbumsOwnerNameAndPicCount(context);
            // ListIncludedInMoreThanTwoAlbumsPictures(context);
        }

        private static void ListIncludedInMoreThanTwoAlbumsPictures(Context context)
        {
            var pictures = context.Pictures
                                  .Where(p => p.Albums.Count > 2)
                                  .OrderByDescending(pc => pc.Albums.Count)
                                  .ThenBy(t => t.Title);

            foreach (var picture in pictures)
            {
                Console.WriteLine($"Title: {picture.Title}");

                foreach (var album in context.AlbumsPictures.Where(p => p.PictureId == p.Id))
                {
                    Console.WriteLine($"Album name: {album.Album.Name}");
                    Console.WriteLine($"Album owner: {album.Album.Owner.Username}");
                }

                Console.WriteLine();
            }
        }

        private static void SeedAlbumsWithPictures(Context context)
        {
            Console.WriteLine("Seeding albums with pictures...");

            foreach (var album in context.Albums)
            {
                for (int i = 0; i < new Random().Next(4, 30); i++)
                {
                    var randomPIC = context.Pictures
                                           .Find(new Random().Next(1, 40));

                    if (!album.Pictures.Any(p => p.Picture == randomPIC))
                    {
                        album.Pictures.Add(new AlbumsPictures(album.Id, randomPIC.Id));
                    }
                }
            }

            context.SaveChanges();
        }

        private static void SeedPictures(Context context)
        {
            Console.WriteLine("Seeding Pictures...");

            for (int i = 0; i < 40; i++)
            {
                context.Pictures.Add
                    (
                        new Picture()
                        {
                            Title = $"Title-{i}",
                            Caption = $"Caption-{i}",
                            FilePath = $"FilePath-{i}"
                        }
                    );
            }

            context.SaveChanges();
        }

       

        private static void ListAllAlbumsOwnerNameAndPicCount(Context context)
        {
            var albums = context.Albums
                                .OrderByDescending(pc => pc.Pictures.Count)
                                .ThenBy(on => on.Owner.Username);

            foreach (var album in albums)
            {
                Console.WriteLine($"Album title: {album.Name}");
                Console.WriteLine($"Owner name: {context.Users.Find(album.OwnerId).Username}");
                Console.WriteLine($"Picures count: {context.AlbumsPictures.Where(a => a.AlbumId == album.Id).Count()}");
                Console.WriteLine();
            }
        }

        private static void ListAllUsersAndFriendsCount(Context context)
        {
            var users = context.Users
                               .OrderByDescending(fc => fc.Friends.Count)
                               .ThenBy(u => u.Username);

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Friends: {user.Friends.Count}");
                Console.WriteLine("Status: " + (user.IsDeleted ? "Inactive" : "Active"));
                Console.WriteLine();
            }
        }

        private static void ListAllActiveUsersWithMoreThanFiveFriends(Context context)
        {
            var users = context.Users
                               .OrderBy(rd => rd.RegisteredOn)
                               .ThenByDescending(fc => fc.Friends.Count);

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Friends: {user.Friends.Count}");
                Console.WriteLine($"Active for {(DateTime.Now - user.RegisteredOn).Days} days.");
                Console.WriteLine();
            }
        }

        

        private static void SeedAlbums(Context context)
        {
            Console.WriteLine("Seeding albums...");

            for (int i = 0; i < 30; i++)
            {
                var owner = context.Users.Find(new Random().Next(1, 15));

                context.Albums.Add
                    (
                        new Album()
                        {
                            Name = $"Album-{i + 1}",
                            BackgroundColor = $"Color-{i + 1}",
                            IsPublic = (new Random().NextDouble() >= 0.5),
                            Owner = owner
                        }
                    );
            }

            context.SaveChanges();
        }

        private static void SeedFriends(Context context)
        {
            Console.WriteLine("Seeding friends...");

            foreach (var user in context.Users)
            {
                for (int i = 0; i < (new Random().Next(1, 7)); i++)
                {
                    // Get random user from DB
                    var randomUser = context.Users
                                            .Find(new Random()
                                            .Next(1, 15));

                    //If the random user is not friend of current user add him to friends
                    if (user.Friends.Any(u => u == randomUser) || randomUser == user)
                    {
                        i--;
                        continue;
                    }

                    user.Friends.Add(randomUser);
                }
            }

            context.SaveChanges();
        }

        private static void SeedUsers(Context context)
        {
            Console.WriteLine("Seeding users...");

            for (int i = 0; i < 15; i++)
            {
                context.Users.Add
                    (
                        new User()
                        {
                            Username = $"User-{i + 1}",
                            Password = $"Ulw_{i + 1}",
                            Email = $"email{i + 1}@gmail.com",
                            RegisteredOn = DateTime.Now,
                            Age = Convert.ToByte(i + (new Random().Next(10, 20))),
                            IsDeleted = (new Random().NextDouble() >= 0.5),
                        }
                    );
            }

            context.SaveChanges();
        }

    }
}
