using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class ServerRouteConfig : IServerRouteConfig
{
    private readonly IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> routes;

    public ServerRouteConfig(IAppRouteConfig appRouteConfig)
    {
        this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();

        var requestMethods = Enum.GetValues(typeof(HttpRequestMethod))
                                 .Cast<HttpRequestMethod>();

        foreach (var method in requestMethods)
        {
            this.routes[method] = new Dictionary<string, IRoutingContext>();
        }

        this.InitializeServerConfig(appRouteConfig);
    }

    public IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes => routes;

    private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
    {
        foreach (var kvp in appRouteConfig.Routes)
        {
            var requestMethod = kvp.Key;
            var routesWithHandlers = kvp.Value;

            foreach (var routeHandler in routesWithHandlers)
            {
                var route = routeHandler.Key;
                var handler = routeHandler.Value;
                                
                var parameters = new List<string>();
                var parsedRegex = this.ParseRoute(route, parameters);
                var routingContext = new RoutingContext(handler, parameters);
                this.routes[requestMethod].Add(parsedRegex, routingContext);
            }
        }

    }

    private string ParseRoute(string route, List<string> args)
    {
        if(route == "/")
        {
            return "^/$";
        }

        var result = new StringBuilder();
        result.Append("^/");
        
        var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        ParseTokens(args, tokens, result);

        return result.ToString();
    }

    private void ParseTokens(List<string> args, string[] tokens, StringBuilder parsedRegex)
    {
        for (int idx = 0; idx < tokens.Length; idx++)
        {
            var end = idx == tokens.Length - 1 ? "$" : "/";
            var currentToken = tokens[idx];

            if (!currentToken.StartsWith("{") && !currentToken.EndsWith("}"))
            {
                parsedRegex.Append($"{currentToken}{end}");
                continue;
            }
            
            var match = Regex.Match("<\\w+", currentToken);

            if(!match.Success)
            {
                throw new InvalidOperationException($"Route parameter in '{currentToken}' is not valid.");
            }

            var parameter = match.Value.Substring(1, match.Length - 2);
            
            args.Add(parameter);

            var currentTokenWithoutCurlyBrackets = currentToken.Substring(1, currentToken.Length - 2);

            parsedRegex.Append($"{currentTokenWithoutCurlyBrackets}{end}");
        }
    }
}
