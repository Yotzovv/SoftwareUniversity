using _01._ASP.NET_Core_Introduction.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _01._ASP.NET_Core_Introduction.Middleware
{
    public class HtmlContentTypeMiddleware
    {
        private readonly RequestDelegate next;

        public HtmlContentTypeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(HttpHeader.ContentType, "text/html");

            return this.next(context);
        }
    }
}
