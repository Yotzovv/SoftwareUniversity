namespace SalesDB2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesDB2.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SalesDB2.SalesContext";
        }

        protected override void Seed(SalesDB2.SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "Car", Discription = "vechicle" });
            context.Products.AddOrUpdate(new Product() { Name = "Motorcycle", Discription = "vechicle" });
            context.Products.AddOrUpdate(new Product() { Name = "Truck", Discription = "vechicle" });

            context.Customers.AddOrUpdate(new Customer() { FirstName = "Teo", LastName = "Todorov" });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Mitko", LastName = "Ivanov" });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Ivan", LastName = "Stoyanov" });
        }
    }
}
