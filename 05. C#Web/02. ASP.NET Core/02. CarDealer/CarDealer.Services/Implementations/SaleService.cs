using System.Collections.Generic;
using CarDealer.Services.Models;
using CarDealer.Web;
using System.Linq;

namespace CarDealer.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleListModel> All()
            => this.db
                   .Sales
                   .Select(x => new SaleListModel
                   {
                       Id = x.Id,
                       CustomerName = x.Customer.Name,
                       Price = x.Car.Parts.Sum(p => p.Part.Price),
                       IsYoungDriver = x.Customer.IsYoungDriver,
                       Discount = x.Discount
                   })
                   .ToList();

        public SaleDetailsModel Details(int id)
            => this.db
                   .Sales
                   .Where(s => s.Id == id)
                   .Select(x => new SaleDetailsModel
                   {
                       Id = x.Id,
                       CustomerName = x.Customer.Name,
                       Price = x.Car.Parts.Sum(p => p.Part.Price),
                       IsYoungDriver = x.Customer.IsYoungDriver,
                       Discount = x.Discount,
                       Car = new CarModel
                       {
                           Make = x.Car.Make,
                           Model = x.Car.Model,
                           TravelledDistance = x.Car.TravelledDistance
                       }
                   })
                   .FirstOrDefault();
    }
}
