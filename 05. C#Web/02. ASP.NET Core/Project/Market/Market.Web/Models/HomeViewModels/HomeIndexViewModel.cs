using Market.Data.Models.Enums;
using Market.Services.Model;
using System.Collections.Generic;

namespace Market.Web.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductListingServiceModel> Stocks { get; set; }
            = new List<ProductListingServiceModel>();
        
        public string SearchText { get; set; }

        public Categories? Category { get; set; }

        public string Country { get; set; }

        public string Area { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }
    }
}
