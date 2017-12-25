using Market.Services.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Web.Models.HomeViewModels
{
    public class SearchViewModel : HomeIndexViewModel
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }
            = new List<UserListingServiceModel>();

        public void Filter()
        {
            if(!string.IsNullOrWhiteSpace(Area))
            {
                Stocks = Stocks.Where(x => x.Area == Area);
                Users = Users.Where(x => x.Area == Area);
            }

            if(!string.IsNullOrWhiteSpace(Country))
            {
                Stocks = Stocks.Where(x => x.Country == Country);
                Users = Users.Where(x => x.Country == Country);
            }

            if(Category.HasValue)
            {
                Stocks = Stocks.Where(x => x.Category == Category);
            }

            if(MinPrice > 0)
            {
                Stocks = Stocks.Where(x => x.Price >= MinPrice);
            }

            if(MaxPrice > 0 &&  MaxPrice > MinPrice)
            {
                Stocks = Stocks.Where(x => x.Price <= MaxPrice);
            }
        }
    }
}
