using Microsoft.AspNetCore.Http;
using System;

namespace _01._ASP.NET_Core_Introduction.Middleware.Handlers
{
    public interface IHandler
    {
        int Order { get; }

        Func<HttpContext, bool> Condition { get; }

        RequestDelegate RequestHandler { get; }
    }
}
