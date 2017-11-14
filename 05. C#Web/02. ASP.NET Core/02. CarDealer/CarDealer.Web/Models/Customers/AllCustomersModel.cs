using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Web.Models.Customers
{
    public class AllCustomersModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }

        public OrderDirection OrderDirection { get; set; }
    }
}
