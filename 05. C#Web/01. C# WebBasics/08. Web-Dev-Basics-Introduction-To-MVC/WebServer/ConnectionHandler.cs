namespace WebServer
{
    using Common;
    using Http;
    using Http.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using System.Linq;
    using global::WebServer.Http.Response;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IHandleable mvcRequestHandler;
        private readonly IHandleable resourceHandler;

        public ConnectionHandler(Socket client, IHandleable mvcRequestHandler, IHandleable resourceHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(mvcRequestHandler, nameof(mvcRequestHandler));
            CoreValidator.ThrowIfNull(resourceHandler, nameof(resourceHandler));

            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
            this.resourceHandler = resourceHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                var httpResponse = await this.HandleRequest(httpRequest);
                var responseBytes = await this.GetResponseBytes(httpResponse);
                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }
            
            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<byte[]> GetResponseBytes(object httpResponse)
        {
            var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString()).ToList();

            if(httpResponse is FileResponse)
            {
                responseBytes.AddRange(((FileResponse)httpResponse).FileData);
            }

            return responseBytes.ToArray();
        }

        private async Task<IHttpResponse> HandleRequest(IHttpRequest httpRequest)
        {
            if(httpRequest.Path.Contains("."))
            {
                return this.resourceHandler.Handle(httpRequest);
            }
            else
            {
                string sessionIdToSend = this.SetRequestSession(httpRequest);

                var response = this.mvcRequestHandler.Handle(httpRequest);

                this.SetResponseSession(response, sessionIdToSend);

                return response;
            }
        }

        private void SetResponseSession(IHttpResponse response, string sessionIdToSend)
        {
            throw new NotImplementedException();
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            
            var data = new ArraySegment<byte>(new byte[1024]);
            
            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }
            
            return new HttpRequest(result.ToString());
        }
    }
}
