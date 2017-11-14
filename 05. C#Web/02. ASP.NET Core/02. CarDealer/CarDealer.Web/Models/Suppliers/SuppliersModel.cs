using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Web.Models.Suppliers
{
    public class SuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierListingModel> Suppliers { get; set; }
    }
}
