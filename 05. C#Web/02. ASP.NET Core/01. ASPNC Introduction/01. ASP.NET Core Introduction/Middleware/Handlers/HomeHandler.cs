using System;
using Microsoft.AspNetCore.Http;
using _01._ASP.NET_Core_Introduction.Infrastructure;
using _01._ASP.NET_Core_Introduction.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace _01._ASP.NET_Core_Introduction.Middleware.Handlers
{
    public class HomeHandler : IHandler
    {
        public int Order => 1;

        public Func<HttpContext, bool> Condition => ctx =>
                                                    ctx.Request
                                                       .Path
                                                       .Value == "/" 
                                                     && ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler => async (context) =>
        {
            var env = context.RequestServices.GetRequiredService<IHostingEnvironment>();

            await context.Response.WriteAsync($"<h1>{env.ApplicationName}</h1>");

            var db = context.RequestServices.GetRequiredService<CatsDbContext>();

            using (db)
            {
                var catData = db.Cats
                                 .Select(c => new
                                 {
                                     c.Id,
                                     c.Name
                                 })
                                 .ToList();

                await context.Response.WriteAsync("<ul>");

                foreach (var cat in catData)
                {
                    await context.Response.WriteAsync($@"<li><a href=""/cat/{cat.Id}"">{cat.Name}</li>");
                }

                await context.Response.WriteAsync("</ul>");
                await context.Response.WriteAsync(@"
                              <form action=""/cat/add"">
                                    <input type=""submit"" value=""Add Cat"" />
                              </form>");
            }
        };
    }
}
