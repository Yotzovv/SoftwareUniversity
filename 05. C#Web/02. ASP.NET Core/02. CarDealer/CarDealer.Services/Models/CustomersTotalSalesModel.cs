using System.Collections.Generic;
using System.Linq;

namespace CarDealer.Services.Models
{
    public class CustomersTotalSalesModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }
        
        public decimal TotalMoneySpent
            => this.BoughtCars.Sum(c => c.Price * (1 - (decimal)c.Discount)) * (this.IsYoungDriver ? 0.95m : 1);

    }
}
