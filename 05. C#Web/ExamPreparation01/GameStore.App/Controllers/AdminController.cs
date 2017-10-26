﻿using GameStore.App.Data.Models;
using GameStore.App.Models.Games;
using GameStore.App.Services;
using GameStore.App.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using System.Linq;

namespace GameStore.App.Controllers
{
    public class AdminController : BaseController
    {
        public const string AddGameError = "<p>Check your form for errors.</p><p>Title has to begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Price must be a positive number with precision up to 2 digits after floating point.</p><p>Size must be a positive number with precision up to 1 digit after floating point.</p><p>Videos should only be from YouTube.</p><p>Thumbnail URL should be a plain text starting with http://, https://.</p><p>Description must be at least 20 symbols.</p>";

        private readonly IGameService games;

        public AdminController()
        {
            this.games = new GameService();
        }

        public IActionResult All()
        {
            if (!this.Profile.IsAdmin)
            {
                return this.Redirect("/");
            }

            var allgames = this.games
                            .All()
                            .Select(g => $@"
                                    <tr>
                                        <td>{g.Id}</td>
                                        <td>{g.Name}</td>
                                        <td>{g.Size}</td>
                                        <td>{g.Price} &euro</td>
                                        <td>
                                            <a class=""btn btn-warning btn-sm"" href=""/admin/edit?id={g.Id}"">Edit</a>
                                            <a class=""btn btn-danger btn-sm"" href=""/admin/delete?id={g.Id}"">Delete</a>
                                        </td>
                                    </tr>");

            this.ViewModel["games"] = string.Join(string.Empty, allgames);

            return this.View();
        }

        public IActionResult Edit(int id)
        {
            if(!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var game = this.games.GetById(id);

            if(game == null)
            {
                return this.NotFound();
            }

            this.SetGameViewData(game);

            return this.View();
        }

        public void SetGameViewData(Game game)
        {
            this.ViewModel["title"] = game.Title;
            this.ViewModel["description"] = game.Description;
            this.ViewModel["thumbnail"] = game.ThumbnailUrl;
            this.ViewModel["price"] = game.Price.ToString();
            this.ViewModel["size"] = game.Size.ToString();
            this.ViewModel["video-id"] = game.VideoId;
            this.ViewModel["release-date"] = game.ReleaseDate.ToString("mm/dd/yyyy");
        }


        public IActionResult Delete(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var game = this.games.GetById(id);

            if (game == null)
            {
                return this.NotFound();
            }

            this.ViewModel["id"] = id.ToString();
            this.SetGameViewData(game);

            return this.View();
        }
        
        [HttpPost]
        public IActionResult Destroy(int id)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var game = this.games.GetById(id);

            if (game == null)
            {
                return this.NotFound();
            }

            this.games.Delete(id);

            return this.Redirect("/admin/all");
        }

        [HttpPost]
        public IActionResult Edit(int id, GameAdminModel model)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(AddGameError);
                return this.View();
            }

            this.games.Update
                (
                    id,
                    model.Title,
                    model.Description,
                    model.ThumbnailUrl,
                    model.Price,
                    model.Size,
                    model.VideoId,
                    model.ReleaseDate
                );

            return this.Redirect("/admin/all");

            return this.View();
        }

        public IActionResult Add()
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(GameAdminModel model)
        {
            if (!this.IsAdmin)
            {
                return this.Redirect("/");
            }

            if (!this.IsValidModel(model))
            {
                this.ShowError(AddGameError);
                return this.View();
            }

            this.games.Create
                (
                    model.Title,
                    model.Description,
                    model.ThumbnailUrl,
                    model.Price,
                    model.Size,
                    model.VideoId,
                    model.ReleaseDate
                );

            return this.Redirect("/admin/all");
        }
    }
}
