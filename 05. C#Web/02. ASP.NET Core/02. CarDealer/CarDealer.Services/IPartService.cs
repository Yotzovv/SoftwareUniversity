using CarDealer.Services.Models;
using System.Collections.Generic;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10);

        int Total();

        void Create(string name, decimal price, int quantity, int supplierId);

        void Delete(int id);

        PartDetailsModel ById(int id);

        void Edit(int id, decimal price, int quantity);
    }
}
