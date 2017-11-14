using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> AllListings(bool isImporter);

        IEnumerable<SupplierModel> All();
    }
}
