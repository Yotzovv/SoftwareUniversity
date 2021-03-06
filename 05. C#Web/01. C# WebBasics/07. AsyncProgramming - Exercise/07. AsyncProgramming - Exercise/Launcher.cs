﻿using MyCoolWebServer.GameStoreApplication;
using System;

namespace _07._AsyncProgramming___Exercise
{
    class Launcher : IRunnable
    {
        private WebServer webServer;

        static void Main(string[] args)
         {
            new Launcher().Run();
        }

        public void Run()
        {
            var app = new GameStoreApp();
            app.InitializeDatabase();

            var appRouteConfig = new AppRouteConfig();
            app.Configure(appRouteConfig);

            this.webServer = new WebServer(1337, appRouteConfig);

            this.webServer.Run();
        }
    }
}
