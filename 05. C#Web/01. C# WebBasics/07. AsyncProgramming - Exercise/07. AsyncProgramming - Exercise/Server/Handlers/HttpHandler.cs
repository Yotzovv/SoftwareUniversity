﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

public class HttpHandler : IRequestHandler
{
    private readonly IServerRouteConfig serverRouteConfig;

    public HttpHandler(IServerRouteConfig serverRouteConfig)
    {
        CoreValidator.ThrowIfNull(serverRouteConfig, nameof(serverRouteConfig));

        this.serverRouteConfig = serverRouteConfig;
    }

    public IHttpResponse Handle(IHttpContext context)
    {
        try
        {
            // Check if user is authenticated
            var anonymousPaths = new[] { "/login", "/register" };

            if (!anonymousPaths.Contains(context.Request.Path) &&
                (context.Request.Session == null || !context.Request.Session.Contains(SessionStore.CurrentUserSessionKey)))
            {
                return new RedirectResponse(anonymousPaths.First());
            }

            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                var routePattern = registeredRoute.Key;
                var routingContext = registeredRoute.Value;

                var routeRegex = new Regex(routePattern);
                var match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;

                foreach (var parameter in parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;
                    context.Request.AddUrlParameter(parameter, parameterValue);
                }

                return routingContext.RequestHandler.Handle(context);
            }
        }
        catch (Exception ex)
        {
            return new InternalServerErrorResponse(ex);
        }

        return new NotFoundResponse();
    }
}
