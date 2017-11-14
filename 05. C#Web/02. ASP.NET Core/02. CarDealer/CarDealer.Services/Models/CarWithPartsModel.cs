using System.Collections.Generic;

namespace CarDealer.Services.Models
{
    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
