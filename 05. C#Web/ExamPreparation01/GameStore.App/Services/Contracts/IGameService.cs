using GameStore.App.Data.Models;
using GameStore.App.Models.Models;
using System;
using System.Collections.Generic;

namespace GameStore.App.Services.Contracts
{
    public interface IGameService
    {
        Game GetById(int id);

        void Delete(int id);

        void Create(string title, string description, string thumbnailUrl, decimal price, double size, string videoId, DateTime releaseDate);

        IEnumerable<GameListingAdminModel> All();

        void Update(int id, string title, string description, string thumbnailUrl, decimal price, double size, string videoId, DateTime releaseDate);
    }
}
