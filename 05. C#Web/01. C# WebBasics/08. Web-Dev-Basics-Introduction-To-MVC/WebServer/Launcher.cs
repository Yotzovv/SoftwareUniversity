namespace WebServer
{
    public class Launcher
    {
        var server = new WebServer(8000, new ControllerRouter());
    }
}
