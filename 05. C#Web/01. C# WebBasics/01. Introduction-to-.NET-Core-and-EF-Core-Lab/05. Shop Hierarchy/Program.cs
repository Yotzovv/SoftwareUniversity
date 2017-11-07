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
                context.Salesmen.Add(new Salesman(name));
            }

            context.SaveChanges();
        }

        private static void ReadCommands(AppDbContext context)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var customer = input.Split('-')[1].Split(';')[0];
                var salesmanID = int.Parse(input.Split('-')[1].Split(';')[1]);

                Register(context, salesmanID, customer);
            }
        }

        private static void Register(AppDbContext context, int salesmanID, string customer)
        {
            context.Customers.Add(new Customer(customer));
            context.Salesmen[salesmanID - 1].Customers.Add(new Customer(customer));

            context.SaveChanges();
        }

        private static void PrintSalesmenWithCustomersCount(AppDbContext context)
        {
            var salesmen = context.Salesmen
                                  .OrderByDescending(x => x.Customers.Count)
                                  .ThenBy(x => x.Name);

            foreach (var salesman in salesmen)
            {
                Console.WriteLine($"{salesman.Name} - {salesman.Customers.Count} customers");
            }
        }

    }
}
