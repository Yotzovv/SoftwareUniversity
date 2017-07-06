namespace BookShopSystem.Client
{
    using System;
    using System.Linq;
    using Data;
    using BookShopSytem.Models;
    using System.Globalization;
    using System.Data.SqlClient;
    using System.Data.Entity;

    class Program
    {
        static void Main()
        {
            // BooksTitleByAgeRestriction();
            // GoldenBooks();
            //  NotReleasedBooks();
            // BookTitlesByCategory();
            // BooksReleasedBeforeDate();
            // AuthorsSearch();
            // BookSearch();
            //  CountBooks();
            // TotalBookCopies();
            // FindProfit();
            // MostRecentBooks(); BooksCategories Table is fucked up
            // IncreaseBookCopies();
            // RemoveBooks();
            StoredProcedure();
        }

        public static void BooksTitleByAgeRestriction()
        {
            BookShopContext context = new BookShopContext();
            string input = Console.ReadLine();
            AgeRestriction restriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), input, true);

            foreach (var book in context.Books.Where(s => s.AgeRestriction == restriction))
            {
                Console.WriteLine(book.Title);
            }

        }

        public static void GoldenBooks()
        {
            BookShopContext context = new BookShopContext();
            EditionType golden = (EditionType)Enum.Parse(typeof(EditionType), "Gold", true);

            foreach (var book in context.Books.Where(s => s.EditionType == golden && s.Copies < 5000).OrderBy(d => d.Id))
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void NotReleasedBooks()
        {
            BookShopContext context = new BookShopContext();
            int year = int.Parse(Console.ReadLine());

            foreach (var book in context.Books.Where(s => s.ReleaseDate.Value.Year != year).OrderBy(x => x.Id))
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(string.Join(" ", book.Categories));
            }
        }

        public static void BookTitlesByCategory()
        {
            BookShopContext context = new BookShopContext();
            string[] categories = Console.ReadLine().Split().ToArray();

            foreach (var category in categories)
            {
                foreach (var book in context.Books.Where(c => c.Categories.Any(d => d.Name == category)).OrderBy(s => s.Id))
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        public static void BooksReleasedBeforeDate()
        {
            BookShopContext context = new BookShopContext();
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            foreach (var book in context.Books.Where(a => a.ReleaseDate < date))
            {
                Console.WriteLine($"{book.Title} - {book.EditionType} - {book.Price}");
            }
        }

        public static void AuthorsSearch()
        {
            BookShopContext context = new BookShopContext();
            string input = Console.ReadLine();

            foreach (var author in context.Authors.Where(a => a.FirstName.EndsWith(input)))
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        public static void BookSearch()
        {
            BookShopContext context = new BookShopContext();
            string input = Console.ReadLine();

            foreach (var book in context.Books.Where(t => t.Title.Contains(input)))
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void CountBooks()
        {
            BookShopContext context = new BookShopContext();
            int n = int.Parse(Console.ReadLine());
            int output = context.Books.Where(t => t.Title.Length > n).Count();

            Console.WriteLine(output);
        }

        public static void TotalBookCopies()
        {
            BookShopContext context = new BookShopContext();

            foreach (var author in context.Authors.OrderByDescending(a => a.Books.Sum(c => c.Copies)))
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Sum(a => a.Copies)}");
            }
        }

        public static void FindProfit()
        {
            BookShopContext context = new BookShopContext();

            foreach (var category in context.Categories)
            {
                decimal totalSum = 0;
                foreach (var book in category.Books)
                {
                    totalSum += book.Copies * book.Price;
                }
                Console.WriteLine($"{category.Name} - {totalSum}");
            }
        }

        public static void MostRecentBooks()
        {
            BookShopContext context = new BookShopContext();
            foreach (var category in context.Categories.Where(c => c.Books.Count > 35))
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count}");

                foreach (var book in category.Books.OrderByDescending(d => d.ReleaseDate).ThenBy(t => t.Title).Take(3))
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        public static void IncreaseBookCopies()
        {
            BookShopContext context = new BookShopContext();
            int totalNumOdBooks = 0;


            foreach (var book in context.Books.Where(b => b.ReleaseDate > new DateTime(2013 - 06 - 06)))
            {
                book.Copies += 44;
                totalNumOdBooks += 44;
            }
            Console.WriteLine(totalNumOdBooks);
        }

        public static void RemoveBooks()
        {
            BookShopContext context = new BookShopContext();
            int deletedBookz = 0;

            foreach (var book in context.Books.Where(c => c.Copies < 4200))
            {
                context.Books.Remove(book);
                deletedBookz++;
            }
            Console.WriteLine($"{deletedBookz} books were deleted.");
            context.SaveChanges();
        }

        public static void StoredProcedure()
        {
            BookShopContext context = new BookShopContext();
            string[] author = Console.ReadLine().Split().ToArray();
            string query = "EXEC WrittenBooks @FirstName, @LastName";

            SqlParameter firstName = new SqlParameter("@FirstName", author[0]);
            SqlParameter LastName = new SqlParameter("@LastName", author[1]);

            var projects = context.Database.SqlQuery<int>(query, firstName, LastName).FirstOrDefault();
            Console.WriteLine($"{author[0]} {author[1]} has written {projects} books");
        }
    }
}