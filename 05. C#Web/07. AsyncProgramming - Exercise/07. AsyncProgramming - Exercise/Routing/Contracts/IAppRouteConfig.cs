using System.Collections.Generic;

public interface IAppRouteConfig
{
    IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes
    {
        get;
    }

    void AddRoute(string route, HttpRequestMethod method, RequestHandler httpHandler);
}

