using Microsoft.AspNetCore.Http;

namespace _01._ASP.NET_Core_Introduction.Infrastructure.Extension
{
    public static class HttpResponseExtensions
    {
        public static void Redirect(this HttpResponse response, string url)
        {
            response.StatusCode = HttpStatusCode.Found;
            response.Headers.Add(HttpHeader.Location, url);
        }
    }
}
