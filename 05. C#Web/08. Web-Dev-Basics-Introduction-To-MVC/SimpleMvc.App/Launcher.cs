using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace SimpleMvc.App
{
    class Launcher
    {
        static void Main(string[] args)
        {
            MvcEngine.Run(new WebServer.WebServer(8000, new ControllerRouter()));
        }
    }
}
