using System.Collections.Generic;

namespace SalesDB2
{
    public class StoreLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<Sale> SalesForCustomer { get; set; }
    }
}