public class MainApplication : IApplication
{
    public void Start(IAppRouteConfig appRouteConfig)
    {
        appRouteConfig.AddRoute("/", HttpRequestMethod.Get ,new GetHandler(HttpContext => new HomeController().Index()));
    }
}
