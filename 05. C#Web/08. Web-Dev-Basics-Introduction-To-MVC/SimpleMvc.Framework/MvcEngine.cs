using System;
using System.Reflection;

namespace SimpleMvc.Framework
{
    public static class MvcEngine
    {
        public static void Run(WebServer.WebServer server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        private static void RegisterControllersData()
        {
            MvcContext.Get.ControllersFolder = "Controllers";
            MvcContext.Get.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Get.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Get.ModelsFolder = "Models";
        }
    }
}
