namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookShopSystem.Models;
    using Data;
    using System.IO;
    using static Models.Book;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopSystem.Context context)
        {
            //context.Categories.AddOrUpdate
            //    (
            //         new Category()
            //         {
            //             Name = "Fantasy",
            //         },

            //        new Category()
            //        {
            //            Name = "Thriller",
            //        },

            //        new Category()
            //        {   
            //            Name = "Fiction",
            //        },

            //        new Category()
            //        {
            //            Name = "Mistery",
            //        },

            //        new Category()
            //        {
            //            Name = "Science Fiction",
            //        },

            //        new Category()
            //        {
            //            Name = "Romance",
            //        },

            //        new Category()
            //        {
            //            Name = "Historical",
            //        },

            //        new Category()
            //        {
            //            Name = "Crime",
            //        }                  
            //    );

            ////-----------------
            //context.Authors.AddOrUpdate
            //    (
            //        new Author()
            //        {
            //            FirstName = "Roger",
            //            LastName = "Porter",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Jeffrey",
            //            LastName = "Snyder",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Louis",
            //            LastName = "Coleman",
            //        },

            //        new Author()
            //        {
            //            FirstName = "George",
            //            LastName = "Powell",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Jane",
            //            LastName = "Ortiz",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Randy",
            //            LastName = "Morales",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Lisa",
            //            LastName = "Davis",
            //        },

            //        new Author()
            //        {
            //            FirstName = "Brenda",
            //            LastName = "Griffin"
            //        }
            //  );

            ////--------------------------------<

            //context.Books.AddOrUpdate
            //    (

            //        new Book()
            //        {
            //            Type = EditionType.Gold,
            //            ReleaseDate = new DateTime(1998, 1, 20),
            //            Copies = 27274,
            //            Price = 15.31M,
            //            AgeRestrict = AgeRestriction.Minor,
            //            Title = "Absalom"
            //        },

            //        new Book()
            //        {
            //            Type = EditionType.Normal,
            //            ReleaseDate = new DateTime(1998, 1, 20),
            //            Copies = 29025,
            //            Price = 23.71M,
            //            AgeRestrict = AgeRestriction.Teen,
            //            Title = "Ah",
            //        },

            //        new Book()
            //        {
            //            Type = EditionType.Normal,
            //            ReleaseDate = new DateTime(1993, 3, 12),
            //            Copies = 9998,
            //            Price = 5.26M,
            //            AgeRestrict = AgeRestriction.Minor,
            //            Title = "Wilderness",
            //        },

            //        new Book()
            //        {
            //            Type = EditionType.Normal,
            //            ReleaseDate = new DateTime(1998, 4, 23),
            //            Copies = 3226,
            //            Price = 24.37M,
            //            AgeRestrict = AgeRestriction.Adult,
            //            Title = "Wide sea"
            //        }
            //    );
        }
    }
}
