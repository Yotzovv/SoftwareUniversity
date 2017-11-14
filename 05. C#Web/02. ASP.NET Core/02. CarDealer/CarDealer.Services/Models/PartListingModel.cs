namespace CarDealer.Services.Models
{
    public class PartListingModel : PartModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string SupplierName { get; set; }
    }
}
