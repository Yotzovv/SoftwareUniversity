using CarDealer.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Models
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderedCusotmers(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.Name);
                    break;
                case OrderDirection.Descendin:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.Name); ;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}");
            }

            return customersQuery.Select(c => new CustomerModel
            {
                Name = c.Name,
                BirthDay = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            })
            .ToList();
        }

        public CustomersTotalSalesModel TotalSalesById(int id)
        {
            return this.db
                       .Customers
                       .Where(c => c.Id == id)
                       .Select(c => new CustomersTotalSalesModel
                       {
                           Name = c.Name,
                           IsYoungDriver = c.IsYoungDriver,
                           BoughtCars = c.Sales.Select(s => new SaleModel
                           {
                               Price = s.Car.Parts.Sum(p => p.Part.Price),
                               Discount = s.Discount
                           }),
                       })
                       .FirstOrDefault();
        }
    }
}
