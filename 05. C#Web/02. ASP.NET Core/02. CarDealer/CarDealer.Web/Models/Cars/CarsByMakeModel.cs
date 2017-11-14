using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Web.Models.Cars
{
    public class CarsByMakeModel
    {
        public string Make { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}
