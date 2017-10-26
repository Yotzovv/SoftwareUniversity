﻿using GameStore.App.Data;
using GameStore.App.Data.Models;
using GameStore.App.Models.Models;
using GameStore.App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.App.Services
{
    public class GameService : IGameService
    {
        public void Create(string title, string description, string thumbnailUrl, decimal price, double size, string videoId, DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = new Game
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Size = size,
                    ThumbnailUrl = thumbnailUrl,
                    VideoId = videoId,
                    ReleaseDate = releaseDate
                };

                db.Games.Add(game);
                db.SaveChanges();
            }
        }

        public Game GetById(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games.Find(id);
            }
        }
        
        public IEnumerable<GameListingAdminModel> All()
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Games
                         .Select(g =>
                                     new GameListingAdminModel
                                     {
                                         Id = g.Id,
                                         Name = g.Title,
                                         Price = g.Price,
                                         Size = g.Size
                                     })
                                     .ToList();
            }
        }

        public void Delete(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = db.Games.Find(id);

                db.Games.Remove(game);

                db.SaveChanges();
            }
        }

        public void Update(int id, string title, string description, string thumbnailUrl, decimal price, double size, string videoId, DateTime releaseDate)
        {
            using (var db = new GameStoreDbContext())
            {
                var game = db.Games.Find(id);

                game.Title = title;
                game.Description = description;
                game.ThumbnailUrl = thumbnailUrl;
                game.Price = price;
                game.Size = size;
                game.VideoId = videoId;
                game.ReleaseDate = releaseDate;

                db.SaveChanges();
            }
        }
    }
}
