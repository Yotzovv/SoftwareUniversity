using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailsModel Details(int id);
    }
}
