using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                ReadItems(context);
                ReadCommands(context);
                PrintSalesmenWithCustomersCount(context);
            }
        }

        private static void ReadItems(AppDbContext context)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var name = input.Split(';')[0];
                var price = decimal.Parse(input.Split(';')[1]);
                context.Items.Add(new Item(context.Items.Count + 1, name, price));
            }

            context.SaveChanges();
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
                var id = cmd == "register" ? int.Parse(input.Split('-')[1].Split(';')[1]) : int.Parse(input.Split(new char[] { '-', ';' })[1]);
                List<Item> items = input.Split(';').Skip(1).Select(i => context.Items.First(x => x.Id == int.Parse(i))).ToList();

                switch (cmd)
                {
                    case "register":
                        Register(context, id, customer);
                        break;
                    case "order":
                        var order = new Order(context.Customers[id - 1].Orders.Count);
                        order.Items.AddRange(items);
                        context.Customers[id - 1].Orders.Add(order);
                        break;
                    case "review":
                        context.Customers[id - 1].Reviews.Add(new Review(context.Customers[id - 1].Reviews.Count, items.First()));
                        break;
                }
            }

            context.SaveChanges();
        }

        private static void Register(AppDbContext context, int salesmanID, string customer)
        {
            context.Customers.Add(new Customer(customer, salesmanID) { Salesman = context.Salesmen[salesmanID - 1] });
            context.Salesmen[salesmanID - 1].Customers.Add(new Customer(customer, salesmanID));

            context.SaveChanges();
        }

        private static void PrintSalesmenWithCustomersCount(AppDbContext context)
        {
            int customerId = int.Parse(Console.ReadLine());
            var customer = context.Customers[customerId - 1];

            Console.WriteLine($"Orders: {customer.Orders.Where(o => o.Items.Count > 1).Count()}");
        }

    }
}
