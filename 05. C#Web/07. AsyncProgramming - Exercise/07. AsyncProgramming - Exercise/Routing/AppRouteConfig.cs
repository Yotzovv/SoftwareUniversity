using System;
using System.Collections.Generic;
using System.Linq;

public class AppRouteConfig : IAppRouteConfig
{
    private readonly Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> routes;

    public AppRouteConfig()
    {
        this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, RequestHandler>>();

        var availableMethods = Enum.GetValues(typeof(HttpRequestMethod))
                                   .Cast<HttpRequestMethod>();

        foreach (var method in availableMethods)
        {
            routes[method] = new Dictionary<string, RequestHandler>();
        }
    }

    public IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes => this.routes;
    
    public void AddRoute(string route, HttpRequestMethod method, RequestHandler httpHandler)
    {
        var handlerName = httpHandler.GetType().Name.ToLower();

        if(handlerName.Contains("get"))
        {
            this.routes[HttpRequestMethod.Get].Add(route, httpHandler);
        }
        else
        {
            this.routes[HttpRequestMethod.Post].Add(route, httpHandler);
        }
    }
}