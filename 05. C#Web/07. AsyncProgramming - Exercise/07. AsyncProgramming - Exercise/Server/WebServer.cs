using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

public class WebServer : IRunnable
{
    private readonly int port;
    private readonly IServerRouteConfig serverRouteConfig;
    private readonly TcpListener tcpListener;
    private bool IsRunning;
    private const string localHostIpAddres = "127.0.0.1";

    public WebServer(int port, IAppRouteConfig routeConfig)
    {
        this.port = port;
        this.serverRouteConfig = new ServerRouteConfig(routeConfig);
        this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
    }

    public void Run()
    {
        this.tcpListener.Start();
        this.IsRunning = true;

        Console.WriteLine($"Server running on {localHostIpAddres}:{port}");

        Task.Run(this.ListenLoop).Wait();
    }

    private async Task ListenLoop()
    {
        while(this.IsRunning)
        {
            var client = await this.tcpListener.AcceptSocketAsync();
            var connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}