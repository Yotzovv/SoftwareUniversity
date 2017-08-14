namespace ProductsShop
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using Data;

    using Model;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Models;
    using Models.Dtos;

    public class Application
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //ImportData(context);
            QueryAndExportData(context);
        }

        private static void QueryAndExportData(ProductShopContext context)
        {
            //ProductsInRange(context);
            SoldProducts(context);
            //CategoriesByProductsCount(context);
            //UsersAndProducts(context);
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Count > 0)
                                     .OrderByDescending(sp => sp.ProductsSold.Count)
                                     .ThenBy(l => l.LastName)
                                     .Select(s => new UserDto
                                     {
                                         FirstName = s.FirstName,
                                         LastName = s.LastName,
                                         Age = s.Age,
                                         SoldProducts = s.ProductsSold.Select(x => new ProductDto
                                         {
                                             ProductName = x.Name,
                                             Price = x.Price,
                                         }).ToList()
                                     })
                                     .ToList();
            var fileStream = new FileStream("UsersAndProducts.xml", FileMode.Create);
            var xml = new XmlSerializer(users.GetType(), new XmlRootAttribute("users"));
            using (fileStream)
            {
                xml.Serialize(fileStream, users);
            }

        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .OrderBy(p => p.Products.Count)
                                    .Select(x => new CategoryDto
                                    {
                                        Name = x.Name,
                                        ProductsCount = x.Products.Count,
                                        AveragePrice = x.Products.Average(p => p.Price),
                                        totalRevenue = x.Products.Sum(p => p.Price),
                                    }).ToList();
            var fileStream = new FileStream("CategoriesByProductsCount.xml", FileMode.Create);
            var xml = new XmlSerializer(categories.GetType(), new XmlRootAttribute("categories"));
            using (fileStream)
            {
                xml.Serialize(fileStream, categories);
            }
        }

        private static void SoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Count > 0)
                                     .OrderBy(l => l.LastName)
                                     .ThenBy(f => f.FirstName)
                                     .Select(p => new UserDto
                                     {
                                         FirstName = p.FirstName,
                                         LastName = p.LastName,
                                         SoldProducts = p.ProductsSold.Select(ps => new ProductDto
                                         {
                                             ProductName = ps.Name,
                                             Price = ps.Price
                                         }).ToList()
                                     })
                                     .ToList();

            var fileStream = new FileStream("SoldProducts.xml", FileMode.Create);
            var xml = new XmlSerializer(users.GetType(), new XmlRootAttribute("users"));
            using (fileStream)
            {
                xml.Serialize(fileStream, users);
            }
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 1000M && p.Price <= 2000 && p.BuyerId != null)
                                           .OrderBy(p => p.Price)
                                           .Select(p => new ProductDto
                                           {
                                               ProductName = p.Name,
                                               Price = p.Price,
                                               Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                                           })
                                           .ToList();

            var fileStream = new FileStream("ProductsInRange.xml", FileMode.Create);
            var xml = new XmlSerializer(products.GetType(), new XmlRootAttribute("products"));

            using (fileStream)
            {
                xml.Serialize(fileStream, products);
            }
        }

        private static void ImportData(ProductShopContext context)
        {
            ImportUsers(context);
            ImportProducts(context);
            ImportCategories(context);
        }
        
        private static void ImportCategories(ProductShopContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/categories.xml");
            XElement categories = xmlDoc.Root;

            foreach (var category in categories.Elements())
            {
                string name = category.Element("name").Value;
                Random random = new Random();
                List<Product> products = new List<Product>();

                for(int i = 0; i <= random.Next(1, 8);i++)
                {
                    products.Add(context.Products.Find(random.Next(0, context.Products.Count())));
                }


                Category categoryToImport = new Category()
                {
                    Name = name,
                    Products = products,
                };

                context.Categories.Add(categoryToImport);
            }
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/users.xml");
            XElement users = xmlDoc.Root;

            foreach (var user in users.Elements())
            {
                string FirstName = user.Attribute("first-name")?.Value;
                string LastName = user.Attribute("last-name").Value;
                int Age = int.Parse(user.Attribute("age")?.Value ?? "0");

                User userToAdd = new User()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Age = Age,
                    
                };
                context.Users.Add(userToAdd);
            }
            context.SaveChanges();
        }

        private static void ImportProducts(ProductShopContext context)
        {
            XDocument xmlDocument = XDocument.Load("../../Import/products.xml");
            XElement products = xmlDocument.Root;
            Random random = new Random();

            foreach (var product in products.Elements())
            {
                string name = product.Element("name")?.Value;
                decimal price = decimal.Parse(product.Element("price")?.Value ?? "0");

                Product productToImport = new Product()
                {
                    Name = name,
                    Price = price,
                    Seller = context.Users.Find(random.Next(1, context.Users.Count())),
                    Buyer = context.Users.Find(random.Next(0, context.Users.Count() + 10)),
                };
                context.Products.Add(productToImport);
                context.SaveChanges();
            }
        }
    }
}
