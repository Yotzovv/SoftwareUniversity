public class MainApplication : IApplication
{
    public void Configure(IAppRouteConfig appRouteConfig)
    {
        appRouteConfig.Get("/", req => new HomeController().Index());
        appRouteConfig.Get("/testsession", req => new HomeController().SessionTest(req));

    }
}
