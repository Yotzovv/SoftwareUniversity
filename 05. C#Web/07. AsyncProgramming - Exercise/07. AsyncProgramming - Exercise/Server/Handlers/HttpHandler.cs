using System.Text.RegularExpressions;

public class HttpHandler : IRequestHandler
{
    private readonly IServerRouteConfig serverRouteConfig;

    public HttpHandler(IServerRouteConfig serverRouteConfig)
    {
        CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));

        this.serverRouteConfig = serverRouteConfig;
    }

    public IHttpResponse Handle(IHttpContext httpContext)
    {
        var requestMethod = httpContext.Request.Method;
        var requestPath = httpContext.Request.Path;
        var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

        foreach (var registeredRoute in registeredRoutes)
        {
            var routePattern = registeredRoute.Key;
            var routingContext = registeredRoute.Value;

            var match = Regex.Match(routePattern,requestPath);

            if(!match.Success)
            {
                continue;
            }

            var parameters = routingContext.Parameters;

            foreach (var parameter in parameters)
            {
                httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
            }

            return routingContext.RequestHandler.Handle(httpContext);
        }

        return new NotFoundResponse();
    }
}
