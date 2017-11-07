using System;
using Microsoft.AspNetCore.Http;
using _01._ASP.NET_Core_Introduction.Infrastructure;
using _01._ASP.NET_Core_Introduction.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using _01._ASP.NET_Core_Introduction.Data;

namespace _01._ASP.NET_Core_Introduction.Middleware.Handlers
{
    public class AddCatHandler : IHandler
    {
        public int Order => 2;

        public Func<HttpContext, bool> Condition => ctx => ctx.Request.Path.Value == "/cat/add";

        public RequestDelegate RequestHandler => async context =>
        {
            if (context.Request.Method == HttpMethod.Get)
            {
                context.Response.Redirect("/cats-add-form.html");
            }
            else if (context.Request.Method == HttpMethod.Post)
            {
                if (context.Request.HasFormContentType)
                {
                    var formData = context.Request.Form;


                    var age = 0;
                    int.TryParse(formData["Age"], out age);

                    var cat = new Cat
                    {
                        Name = formData["Name"],
                        Age = age,
                        Breed = formData["Breed"],
                        ImageUrl = formData["ImageUrl"],
                    };

                    try
                    {
                        if (string.IsNullOrWhiteSpace(cat.Name)
                        || string.IsNullOrWhiteSpace(cat.Breed)
                        || string.IsNullOrWhiteSpace(cat.ImageUrl))
                        {
                            throw new InvalidOperationException("Invalid cat data.");
                        }

                        var db = context.RequestServices.GetRequiredService<CatsDbContext>();

                        using (db)
                        {
                            db.Add(cat);

                            await db.SaveChangesAsync();
                        }

                        context.Response.Redirect("/");
                    }
                    catch
                    {
                        await context.Response.WriteAsync("<h2>Invalid cat data!</h2>");
                        await context.Response.WriteAsync(@"<a href=""/cat/add"">Back To The Form</a>");
                    }
                }
            }
        };
    }
}
