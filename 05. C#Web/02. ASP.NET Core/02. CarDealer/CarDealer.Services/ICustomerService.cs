using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCusotmers(OrderDirection oreder);

        CustomersTotalSalesModel TotalSalesById(int id);
    }
}
