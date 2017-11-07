using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class ConnectionHandler
{
    private readonly Socket client;
    private readonly IServerRouteConfig serverRouteConfig;

    public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
    {
        CoreValidator.ThrowIfNull(client, nameof(client));
        CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));

        this.client = client;
        this.serverRouteConfig = serverRouteConfig;
    }

    public async Task ProcessRequestAsync()
    {
        var request = await ReadRequest();

        if (request != null)
        {
            var httpContext = new HttpContext(request);
            var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);
            var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());
            var byteSegments = new ArraySegment<byte>(responseBytes);

            await this.client.SendAsync(byteSegments, SocketFlags.None);

            Console.WriteLine("---REQUEST---");
            Console.WriteLine(request);

            Console.WriteLine("---RESPONSE---");
            Console.WriteLine(httpResponse);
            Console.WriteLine();
        }

        this.client.Shutdown(SocketShutdown.Both);
    }

    private async Task<IHttpRequest> ReadRequest()
    {
        var request = new StringBuilder();
        var data = new ArraySegment<byte>(new byte[1024]);

        while(true)
        {
            int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

            if(numberOfBytesRead == 0)
            {
                break;
            }

            var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

            request.Append(bytesAsString);

            if(numberOfBytesRead < 1023)
            {
                break;
            }
        }

        if(request.Length == 0)
        {
            return null;
        }

        return new HttpRequest(request.ToString());
    }
}
