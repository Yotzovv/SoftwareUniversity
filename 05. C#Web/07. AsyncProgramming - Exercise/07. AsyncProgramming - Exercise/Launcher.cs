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
            var app = new MainApplication();
            var appRouteConfig = new AppRouteConfig();
            app.Start(appRouteConfig);

            this.webServer = new WebServer(1337, appRouteConfig);
            this.webServer.Run();
        }
    }
}
