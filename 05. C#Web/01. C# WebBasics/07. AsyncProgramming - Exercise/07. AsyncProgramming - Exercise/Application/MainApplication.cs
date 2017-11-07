public class MainApplication : IApplication
{
    public void Configure(IAppRouteConfig appRouteConfig)
    {
        appRouteConfig.Get("/", req => new GameStoreHomeController().Index());
        appRouteConfig.Get("/testsession", req => new GameStoreHomeController().SessionTest(req));

    }
}
