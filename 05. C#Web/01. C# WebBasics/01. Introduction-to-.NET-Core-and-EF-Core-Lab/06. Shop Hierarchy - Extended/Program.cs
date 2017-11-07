using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _05._Shop_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ClearDatabase(context);
                FillSalesmen(context);
                ReadCommands(context);
                PrintSalesmenWithCustomersCount(context);
            }
        }

        private static void ClearDatabase(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void FillSalesmen(AppDbContext context)
        {
            var salesmanNames = Console.ReadLine().Split(';');

            foreach (var name in salesmanNames)
            {
                context.Salesmen.Add(new Salesman(name, context.Salesmen.Count + 1));
            }

            context.SaveChanges();
        }

        private static void ReadCommands(AppDbContext context)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var cmd = input.Split('-')[0];
                var customer = cmd == "register" ? input.Split('-')[1].Split(';')[0] : string.Empty;
                var id = cmd == "register" ? int.Parse(input.Split('-')[1].Split(';')[1]) : int.Parse(input.Split('-')[1]);

                switch (cmd)
                {
                    case "register":
                        Register(context, id, customer);
                        break;
                    case "order":
                        context.Customers[id - 1].Orders.Add(new Order());
                        break;
                    case "review":
                        context.Customers[id - 1].Reviews.Add(new Review());
                        break;
                }
            }

            context.SaveChanges();
        }

        private static void Register(AppDbContext context, int salesmanID, string customer)
        {
            context.Customers.Add(new Customer(customer, salesmanID));
            context.Salesmen[salesmanID - 1].Customers.Add(new Customer(customer, salesmanID));

            context.SaveChanges();
        }

        private static void PrintSalesmenWithCustomersCount(AppDbContext context)
        {
            var results = context.Customers
                                 .OrderByDescending(o => o.Orders.Count)
                                 .OrderByDescending(r => r.Reviews.Count);

            foreach (var customer in results)
            {
                Console.WriteLine(customer.Name);
                Console.WriteLine($"Orders: {customer.Orders.Count}");
                Console.WriteLine($"Reviews: {customer.Reviews.Count}");
            }
        }

    }
}
