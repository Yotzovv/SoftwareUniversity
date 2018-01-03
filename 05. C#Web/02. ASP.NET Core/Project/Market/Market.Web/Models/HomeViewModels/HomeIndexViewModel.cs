using Market.Data.Models.Enums;
using Market.Services.Model;
using PagedList;
using System.Collections.Generic;

namespace Market.Web.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public PagedList<ProductListingServiceModel> Stocks { get; set; }
        
        public string SearchText { get; set; }

        public Categories? Category { get; set; }

        public string Country { get; set; }

        public string Area { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }
    }
}
