using GameStore.App.Data;
using Microsoft.EntityFrameworkCore;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;
using System;

namespace GameStore.App
{
    class Launcher
    {
        static Launcher()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        static void Main(string[] args)
        {
            MvcEngine.Run(new WebServer.WebServer(1337, new ControllerRouter(), new ResourceRouter()));
        }
    }
}